using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Raylib_cs;

/// <summary>
/// Font type, defines generation method
/// </summary>
public enum FontType
{
    /// <summary>
    /// Default font generation, anti-aliased
    /// </summary>
    Default = 0,

    /// <summary>
    /// Bitmap font generation, no anti-aliasing
    /// </summary>
    Bitmap,

    /// <summary>
    /// SDF font generation, requires external shader
    /// </summary>
    Sdf
}

/// <summary>
/// GlyphInfo, font characters glyphs info
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct GlyphInfo
{
    /// <summary>
    /// Character value (Unicode)
    /// </summary>
    public int Value;

    /// <summary>
    /// Character offset X when drawing
    /// </summary>
    public int OffsetX;

    /// <summary>
    /// Character offset Y when drawing
    /// </summary>
    public int OffsetY;

    /// <summary>
    /// Character advance position X
    /// </summary>
    public int AdvanceX;

    /// <summary>
    /// Character image data
    /// </summary>
    public Image Image;
}

/// <summary>
/// Font, font texture and GlyphInfo array data
/// </summary>
[NativeMarshalling(typeof(FontMarshaller))]
[StructLayout(LayoutKind.Sequential)]
public struct Font
{
    /// <summary>
    /// Base size (default chars height)
    /// </summary>
    public int BaseSize;

    /// <summary>
    /// Padding around the glyph characters
    /// </summary>
    public int GlyphPadding;

    /// <summary>
    /// Texture atlas containing the glyphs
    /// </summary>
    public Texture2D Texture;

    /// <summary>
    /// Rectangles in texture for the glyphs
    /// </summary>
    public Rectangle[] Recs;

    /// <summary>
    /// Glyphs info data
    /// </summary>
    public GlyphInfo[] Glyphs;
}

[CustomMarshaller(typeof(Font), MarshalMode.Default, typeof(FontMarshaller))]
internal static unsafe class FontMarshaller
{
    // Unmanaged representation of Font.
    // Should mimic the unmanaged error_data type at a binary level.
    internal struct FontUnmanaged
    {
        public int BaseSize;
        public int GlyphCount;
        public int GlyphPadding;

        public Texture2D Texture;

        public Rectangle* Recs;

        public GlyphInfo* Glyphs;
    }

    public static FontUnmanaged ConvertToUnmanaged(Font managed)
    {
        GlyphInfo* glyphsP = CopyManagedToAllocatedUnmanagedArray(managed.Glyphs);
        Rectangle* recsP = CopyManagedToAllocatedUnmanagedArray(managed.Recs);

        return new FontUnmanaged
        {
            BaseSize = managed.BaseSize,
            GlyphCount = managed.Glyphs.Length,
            GlyphPadding = managed.GlyphPadding,
            Texture = managed.Texture,
            Recs = recsP,
            Glyphs = glyphsP,
        };
    }

    public static Font ConvertToManaged(FontUnmanaged unmanaged)
    {
        GlyphInfo[] glyphsArr = CopyUnmanagedToManagedArray(unmanaged.Glyphs, unmanaged.GlyphCount);
        Rectangle[] recsArr = CopyUnmanagedToManagedArray(unmanaged.Recs, unmanaged.GlyphCount);

        return new Font
        {
            BaseSize = unmanaged.BaseSize,
            GlyphPadding = unmanaged.GlyphPadding,
            Texture = unmanaged.Texture,
            Recs = recsArr,
            Glyphs = glyphsArr,
        };
    }

    private static T* CopyManagedToAllocatedUnmanagedArray<T>(T[] managed) where T : unmanaged
    {
        var unmanagedP = ArrayMarshaller<T, T>.AllocateContainerForUnmanagedElements(managed, out int count);
        var managedSource = ArrayMarshaller<T, T>.GetManagedValuesSource(managed);
        var unmanagedDest = ArrayMarshaller<T, T>.GetUnmanagedValuesDestination(unmanagedP, count);
        managedSource.CopyTo(unmanagedDest);
        return unmanagedP;
    }

    private static T[] CopyUnmanagedToManagedArray<T>(T* unmanaged, int count) where T : unmanaged
    {
        var managedArray = ArrayMarshaller<T, T>.AllocateContainerForManagedElements(unmanaged, count);
        var unmanagedSrc = ArrayMarshaller<T, T>.GetUnmanagedValuesDestination(unmanaged, count);
        var managedDest = ArrayMarshaller<T, T>.GetManagedValuesDestination(managedArray);
        unmanagedSrc.CopyTo(managedDest);
        return managedArray;
    }

    public static void Free(FontUnmanaged unmanaged)
    {
        ArrayMarshaller<GlyphInfo, GlyphInfo>.Free(unmanaged.Glyphs);
        ArrayMarshaller<Rectangle, Rectangle>.Free(unmanaged.Recs);
    }
}