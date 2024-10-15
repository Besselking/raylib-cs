using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs;

public static unsafe partial class Raylib
{
    /// <summary>Set shader uniform value vector</summary>
    public static void SetShaderValueV<T>(
        Shader shader,
        int locIndex,
        T[] values,
        ShaderUniformDataType uniformType,
        int count
    ) where T : unmanaged
    {
        SetShaderValueV(shader, locIndex, (Span<T>)values, uniformType, count);
    }

    /// <summary>Set shader uniform value vector</summary>
    public static void SetShaderValueV<T>(
        Shader shader,
        int locIndex,
        Span<T> values,
        ShaderUniformDataType uniformType,
        int count
    ) where T : unmanaged
    {
        fixed (T* valuePtr = values)
        {
            SetShaderValueV(shader, locIndex, valuePtr, uniformType, count);
        }
    }

    /// <summary>Set shader uniform value</summary>
    public static void SetShaderValue<T>(Shader shader, int locIndex, T value, ShaderUniformDataType uniformType)
    where T : unmanaged
    {
        SetShaderValue(shader, locIndex, &value, uniformType);
    }

    /// <summary>Set shader uniform value</summary>
    public static void SetShaderValue<T>(
        Shader shader,
        int locIndex,
        T[] values,
        ShaderUniformDataType uniformType
    ) where T : unmanaged
    {
        SetShaderValue(shader, locIndex, (Span<T>)values, uniformType);
    }

    /// <summary>Set shader uniform value</summary>
    public static void SetShaderValue<T>(
        Shader shader,
        int locIndex,
        Span<T> values,
        ShaderUniformDataType uniformType
    ) where T : unmanaged
    {
        fixed (T* valuePtr = values)
        {
            SetShaderValue(shader, locIndex, valuePtr, uniformType);
        }
    }

    /// <summary>C++ style memory allocator</summary>
    public static T* New<T>(uint count) where T : unmanaged
    {
        return (T*)MemAlloc(count * (uint)sizeof(T));
    }

    /// <summary>Get dropped files names (memory should be freed)</summary>
    public static string[] GetDroppedFiles()
    {
        var filePathList = LoadDroppedFiles();
        var files = new string[filePathList.Count];

        for (var i = 0; i < filePathList.Count; i++)
        {
            files[i] = Marshal.PtrToStringUTF8((IntPtr)filePathList.Paths[i]);
        }
        UnloadDroppedFiles(filePathList);

        return files;
    }

    /// <summary>Update camera position for selected mode</summary>
    public static void UpdateCamera(ref Camera3D camera, CameraMode mode)
    {
        fixed (Camera3D* c = &camera)
        {
            UpdateCamera(c, mode);
        }
    }

    /// <summary>Update camera movement/rotation</summary>
    public static void UpdateCameraPro(ref Camera3D camera, Vector3 movement, Vector3 rotation, float zoom)
    {
        fixed (Camera3D* c = &camera)
        {
            UpdateCameraPro(c, movement, rotation, zoom);
        }
    }

    /// <summary>Returns the cameras forward vector (normalized)</summary>
    public static Vector3 GetCameraForward(ref Camera3D camera)
    {
        fixed (Camera3D* c = &camera)
        {
            return GetCameraForward(c);
        }
    }

    /// <summary>
    /// Returns the cameras up vector (normalized)<br/>
    /// NOTE: The up vector might not be perpendicular to the forward vector
    /// </summary>
    public static Vector3 GetCameraUp(ref Camera3D camera)
    {
        fixed (Camera3D* c = &camera)
        {
            return GetCameraUp(c);
        }
    }

    /// <summary>Returns the cameras right vector (normalized)</summary>
    public static Vector3 GetCameraRight(ref Camera3D camera)
    {
        fixed (Camera3D* c = &camera)
        {
            return GetCameraRight(c);
        }
    }

    /// <summary>Moves the camera in its forward direction</summary>
    public static void CameraMoveForward(ref Camera3D camera, float distance, bool moveInWorldPlane)
    {
        fixed (Camera3D* c = &camera)
        {
            CameraMoveForward(c, distance, moveInWorldPlane);
        }
    }

    /// <summary>Moves the camera in its up direction</summary>
    public static void CameraMoveUp(ref Camera3D camera, float distance)
    {
        fixed (Camera3D* c = &camera)
        {
            CameraMoveUp(c, distance);
        }
    }

    /// <summary>Moves the camera target in its current right direction</summary>
    public static void CameraMoveRight(ref Camera3D camera, float distance, bool moveInWorldPlane)
    {
        fixed (Camera3D* c = &camera)
        {
            CameraMoveRight(c, distance, moveInWorldPlane);
        }
    }

    /// <summary>Moves the camera position closer/farther to/from the camera target</summary>
    public static void CameraMoveToTarget(ref Camera3D camera, float delta)
    {
        fixed (Camera3D* c = &camera)
        {
            CameraMoveToTarget(c, delta);
        }
    }

    /// <summary>
    /// Rotates the camera around its up vector<br/>
    /// If rotateAroundTarget is false, the camera rotates around its position
    /// </summary>
    public static void CameraYaw(ref Camera3D camera, float angle, bool rotateAroundTarget)
    {
        fixed (Camera3D* c = &camera)
        {
            CameraYaw(c, angle, rotateAroundTarget);
        }
    }

    /// <summary>
    /// Rotates the camera around its right vector
    /// </summary>
    public static void CameraPitch(ref Camera3D camera,
        float angle,
        bool lockView,
        bool rotateAroundTarget,
        bool rotateUp
        )
    {
        fixed (Camera3D* c = &camera)
        {
            CameraPitch(c, angle, lockView, rotateAroundTarget, rotateUp);
        }
    }

    /// <summary>Rotates the camera around its forward vector</summary>
    public static void CameraRoll(ref Camera3D camera, float angle)
    {
        fixed (Camera3D* c = &camera)
        {
            CameraRoll(c, angle);
        }
    }

    /// <summary>Returns the camera view matrix</summary>
    public static Matrix4x4 GetCameraViewMatrix(ref Camera3D camera)
    {
        fixed (Camera3D* c = &camera)
        {
            return GetCameraViewMatrix(c);
        }
    }

    /// <summary>Returns the camera projection matrix</summary>
    public static Matrix4x4 GetCameraProjectionMatrix(ref Camera3D camera, float aspect)
    {
        fixed (Camera3D* c = &camera)
        {
            return GetCameraProjectionMatrix(c, aspect);
        }
    }

    /// <summary>
    /// Check the collision between two lines defined by two points each, returns collision point by reference
    /// </summary>
    public static bool CheckCollisionLines(
        Vector2 startPos1,
        Vector2 endPos1,
        Vector2 startPos2,
        Vector2 endPos2,
        ref Vector2 collisionPoint
    )
    {
        fixed (Vector2* p = &collisionPoint)
        {
            return CheckCollisionLines(startPos1, endPos1, startPos2, endPos2, p);
        }
    }

    public static bool CheckCollisionPointPoly(Vector2 point, Vector2[] points)
    {
        fixed (Vector2* p = points)
        {
            return CheckCollisionPointPoly(point, p, points.Length);
        }
    }

    /// <summary>Convert image to POT (power-of-two)</summary>
    public static void ImageToPOT(ref Image image, Color fill)
    {
        fixed (Image* p = &image)
        {
            ImageToPOT(p, fill);
        }
    }

    /// <summary>Convert image data to desired format</summary>
    public static void ImageFormat(ref Image image, PixelFormat newFormat)
    {
        fixed (Image* p = &image)
        {
            ImageFormat(p, newFormat);
        }
    }

    /// <summary>Apply alpha mask to image</summary>
    public static void ImageAlphaMask(ref Image image, Image alphaMask)
    {
        fixed (Image* p = &image)
        {
            ImageAlphaMask(p, alphaMask);
        }
    }

    /// <summary>Clear alpha channel to desired color</summary>
    public static void ImageAlphaClear(ref Image image, Color color, float threshold)
    {
        fixed (Image* p = &image)
        {
            ImageAlphaClear(p, color, threshold);
        }
    }

    /// <summary>Crop image depending on alpha value</summary>
    public static void ImageAlphaCrop(ref Image image, float threshold)
    {
        fixed (Image* p = &image)
        {
            ImageAlphaCrop(p, threshold);
        }
    }

    /// <summary>Premultiply alpha channel</summary>
    public static void ImageAlphaPremultiply(ref Image image)
    {
        fixed (Image* p = &image)
        {
            ImageAlphaPremultiply(p);
        }
    }

    /// <summary>Apply Gaussian blur using a box blur approximation</summary>
    public static void ImageBlurGaussian(ref Image image, int blurSize)
    {
        fixed (Image* p = &image)
        {
            ImageBlurGaussian(p, blurSize);
        }
    }

    /// <summary>Crop an image to a defined rectangle</summary>
    public static void ImageCrop(ref Image image, Rectangle crop)
    {
        fixed (Image* p = &image)
        {
            ImageCrop(p, crop);
        }
    }

    /// <summary>Resize image (Bicubic scaling algorithm)</summary>
    public static void ImageResize(ref Image image, int newWidth, int newHeight)
    {
        fixed (Image* p = &image)
        {
            ImageResize(p, newWidth, newHeight);
        }
    }

    /// <summary>Resize image (Nearest-Neighbor scaling algorithm)</summary>
    public static void ImageResizeNN(ref Image image, int newWidth, int newHeight)
    {
        fixed (Image* p = &image)
        {
            ImageResizeNN(p, newWidth, newHeight);
        }
    }

    /// <summary>Resize canvas and fill with color</summary>
    public static void ImageResizeCanvas(
        ref Image image,
        int newWidth,
        int newHeight,
        int offsetX,
        int offsetY,
        Color color
    )
    {
        fixed (Image* p = &image)
        {
            ImageResizeCanvas(p, newWidth, newHeight, offsetX, offsetY, color);
        }
    }

    /// <summary>Generate all mipmap levels for a provided image</summary>
    public static void ImageMipmaps(ref Image image)
    {
        fixed (Image* p = &image)
        {
            ImageMipmaps(p);
        }
    }

    /// <summary>Dither image data to 16bpp or lower (Floyd-Steinberg dithering)</summary>
    public static void ImageDither(ref Image image, int rBpp, int gBpp, int bBpp, int aBpp)
    {
        fixed (Image* p = &image)
        {
            ImageDither(p, rBpp, gBpp, bBpp, aBpp);
        }
    }

    /// <summary>Flip image vertically</summary>
    public static void ImageFlipVertical(ref Image image)
    {
        fixed (Image* p = &image)
        {
            ImageFlipVertical(p);
        }
    }

    /// <summary>Flip image horizontally</summary>
    public static void ImageFlipHorizontal(ref Image image)
    {
        fixed (Image* p = &image)
        {
            ImageFlipHorizontal(p);
        }
    }

    /// <summary>Rotate image by input angle in degrees (-359 to 359)</summary>
    public static void ImageRotate(ref Image image, int degrees)
    {
        fixed (Image* p = &image)
        {
            ImageRotate(p, degrees);
        }
    }

    /// <summary>Rotate image clockwise 90deg</summary>
    public static void ImageRotateCW(ref Image image)
    {
        fixed (Image* p = &image)
        {
            ImageRotateCW(p);
        }
    }

    /// <summary>Rotate image counter-clockwise 90deg</summary>
    public static void ImageRotateCCW(ref Image image)
    {
        fixed (Image* p = &image)
        {
            ImageRotateCCW(p);
        }
    }

    /// <summary>Modify image color: tint</summary>
    public static void ImageColorTint(ref Image image, Color color)
    {
        fixed (Image* p = &image)
        {
            ImageColorTint(p, color);
        }
    }

    /// <summary>Modify image color: invert</summary>
    public static void ImageColorInvert(ref Image image)
    {
        fixed (Image* p = &image)
        {
            ImageColorInvert(p);
        }
    }

    /// <summary>Modify image color: grayscale</summary>
    public static void ImageColorGrayscale(ref Image image)
    {
        fixed (Image* p = &image)
        {
            ImageColorGrayscale(p);
        }
    }

    /// <summary>Modify image color: contrast (-100 to 100)</summary>
    public static void ImageColorContrast(ref Image image, float contrast)
    {
        fixed (Image* p = &image)
        {
            ImageColorContrast(p, contrast);
        }
    }

    /// <summary>Modify image color: brightness (-255 to 255)</summary>
    public static void ImageColorBrightness(ref Image image, int brightness)
    {
        fixed (Image* p = &image)
        {
            ImageColorBrightness(p, brightness);
        }
    }

    /// <summary>Modify image color: replace color</summary>
    public static void ImageColorReplace(ref Image image, Color color, Color replace)
    {
        fixed (Image* p = &image)
        {
            ImageColorReplace(p, color, replace);
        }
    }

    /// <summary>Clear image background with given color</summary>
    public static void ImageClearBackground(ref Image dst, Color color)
    {
        fixed (Image* p = &dst)
        {
            ImageClearBackground(p, color);
        }
    }

    /// <summary>Draw pixel within an image</summary>
    public static void ImageDrawPixel(ref Image dst, int posX, int posY, Color color)
    {
        fixed (Image* p = &dst)
        {
            ImageDrawPixel(p, posX, posY, color);
        }
    }

    /// <summary>Draw pixel within an image (Vector version)</summary>
    public static void ImageDrawPixelV(ref Image dst, Vector2 position, Color color)
    {
        fixed (Image* p = &dst)
        {
            ImageDrawPixelV(p, position, color);
        }
    }

    /// <summary>Draw line within an image</summary>
    public static void ImageDrawLine(
        ref Image dst,
        int startPosX,
        int startPosY,
        int endPosX,
        int endPosY,
        Color color
    )
    {
        fixed (Image* p = &dst)
        {
            ImageDrawLine(p, startPosX, startPosY, endPosX, endPosY, color);
        }
    }

    /// <summary>Draw line within an image (Vector version)</summary>
    public static void ImageDrawLineV(ref Image dst, Vector2 start, Vector2 end, Color color)
    {
        fixed (Image* p = &dst)
        {
            ImageDrawLineV(p, start, end, color);
        }
    }

    /// <summary>Draw circle within an image</summary>
    public static void ImageDrawCircle(ref Image dst, int centerX, int centerY, int radius, Color color)
    {
        fixed (Image* p = &dst)
        {
            ImageDrawCircle(p, centerX, centerY, radius, color);
        }
    }

    /// <summary>Draw circle within an image (Vector version)</summary>
    public static void ImageDrawCircleV(ref Image dst, Vector2 center, int radius, Color color)
    {
        fixed (Image* p = &dst)
        {
            ImageDrawCircleV(p, center, radius, color);
        }
    }

    /// <summary>Draw rectangle within an image</summary>
    public static void ImageDrawRectangle(ref Image dst, int posX, int posY, int width, int height, Color color)
    {
        fixed (Image* p = &dst)
        {
            ImageDrawRectangle(p, posX, posY, width, height, color);
        }
    }

    /// <summary>Draw rectangle within an image (Vector version)</summary>
    public static void ImageDrawRectangleV(ref Image dst, Vector2 position, Vector2 size, Color color)
    {
        fixed (Image* p = &dst)
        {
            ImageDrawRectangleV(p, position, size, color);
        }
    }

    /// <summary>Draw rectangle within an image</summary>
    public static void ImageDrawRectangleRec(ref Image dst, Rectangle rec, Color color)
    {
        fixed (Image* p = &dst)
        {
            ImageDrawRectangleRec(p, rec, color);
        }
    }

    /// <summary>Draw a source image within a destination image (tint applied to source)</summary>
    public static void ImageDraw(ref Image dst, Image src, Rectangle srcRec, Rectangle dstRec, Color tint)
    {
        fixed (Image* p = &dst)
        {
            ImageDraw(p, src, srcRec, dstRec, tint);
        }
    }

    /// <summary>Update GPU texture with new data</summary>
    public static void UpdateTexture<T>(Texture2D texture, T[] pixels) where T : unmanaged
    {
        UpdateTexture(texture, (ReadOnlySpan<T>)pixels);
    }

    /// <summary>Update GPU texture with new data</summary>
    public static void UpdateTexture<T>(Texture2D texture, ReadOnlySpan<T> pixels) where T : unmanaged
    {
        fixed (void* pixelPtr = pixels)
        {
            UpdateTexture(texture, pixelPtr);
        }
    }

    /// <summary>Update GPU texture rectangle with new data</summary>
    public static void UpdateTextureRec<T>(Texture2D texture, Rectangle rec, T[] pixels) where T : unmanaged
    {
        UpdateTextureRec(texture, rec, (ReadOnlySpan<T>)pixels);
    }

    /// <summary>Update GPU texture rectangle with new data</summary>
    public static void UpdateTextureRec<T>(Texture2D texture, Rectangle rec, ReadOnlySpan<T> pixels) where T : unmanaged
    {
        fixed (void* pixelPtr = pixels)
        {
            UpdateTextureRec(texture, rec, pixelPtr);
        }
    }

    /// <summary>Generate GPU mipmaps for a texture</summary>
    public static void GenTextureMipmaps(ref Texture2D texture)
    {
        fixed (Texture2D* p = &texture)
        {
            GenTextureMipmaps(p);
        }
    }

    /// <summary>Upload vertex data into GPU and provided VAO/VBO ids</summary>
    public static void UploadMesh(ref Mesh mesh, bool dynamic)
    {
        fixed (Mesh* p = &mesh)
        {
            UploadMesh(p, dynamic);
        }
    }

    /// <summary> Update mesh vertex data in GPU for a specific buffer index </summary>
    public static void UpdateMeshBuffer<T>(Mesh mesh, int index, ReadOnlySpan<T> data, int offset) where T : unmanaged
    {
        fixed (void* dataPtr = data)
        {
            UpdateMeshBuffer(mesh, index, dataPtr, data.Length * sizeof(T), offset);
        }
    }

    /// <summary>Set texture for a material map type (MAP_DIFFUSE, MAP_SPECULAR...)</summary>
    public static void SetMaterialTexture(ref Material material, MaterialMapIndex mapType, Texture2D texture)
    {
        fixed (Material* p = &material)
        {
            SetMaterialTexture(p, mapType, texture);
        }
    }

    /// <summary>Set material for a mesh</summary>
    public static void SetModelMeshMaterial(ref Model model, int meshId, int materialId)
    {
        fixed (Model* p = &model)
        {
            SetModelMeshMaterial(p, meshId, materialId);
        }
    }

    /// <summary>Compute mesh tangents</summary>
    public static void GenMeshTangents(ref Mesh mesh)
    {
        fixed (Mesh* p = &mesh)
        {
            GenMeshTangents(p);
        }
    }

    /// <summary>Convert wave data to desired format</summary>
    public static void WaveFormat(ref Wave wave, int sampleRate, int sampleSize, int channels)
    {
        fixed (Wave* p = &wave)
        {
            WaveFormat(p, sampleRate, sampleSize, channels);
        }
    }

    /// <summary>Crop a wave to defined samples range</summary>
    public static void WaveCrop(ref Wave wave, int initSample, int finalSample)
    {
        fixed (Wave* p = &wave)
        {
            WaveCrop(p, initSample, finalSample);
        }
    }

    /// <summary>Draw lines sequence</summary>
    public static void DrawLineStrip(Vector2[] points, int pointCount, Color color)
    {
        fixed (Vector2* p = points)
        {
            DrawLineStrip(p, pointCount, color);
        }
    }

    /// <summary>Draw a triangle fan defined by points (first vertex is the center)</summary>
    public static void DrawTriangleFan(Vector2[] points, int pointCount, Color color)
    {
        fixed (Vector2* p = points)
        {
            DrawTriangleFan(p, pointCount, color);
        }
    }

    /// <summary>Draw a triangle strip defined by points</summary>
    public static void DrawTriangleStrip(Vector2[] points, int pointCount, Color color)
    {
        fixed (Vector2* p = points)
        {
            DrawTriangleStrip(p, pointCount, color);
        }
    }

    /// <summary>Draw spline: Linear, minimum 2 points</summary>
    public static void DrawSplineLinear(Vector2[] points, int pointCount, float thick, Color color)
    {
        fixed (Vector2* p = points)
        {
            DrawSplineLinear(p, pointCount, thick, color);
        }
    }

    /// <summary>Draw spline: B-Spline, minimum 4 points</summary>
    public static void DrawSplineBasis(Vector2[] points, int pointCount, float thick, Color color)
    {
        fixed (Vector2* p = points)
        {
            DrawSplineBasis(p, pointCount, thick, color);
        }
    }

    /// <summary>Draw spline: Catmull-Rom, minimum 4 points</summary>
    public static void DrawSplineCatmullRom(Vector2[] points, int pointCount, float thick, Color color)
    {
        fixed (Vector2* p = points)
        {
            DrawSplineCatmullRom(p, pointCount, thick, color);
        }
    }

    /// <summary>Draw spline: Quadratic Bezier, minimum 3 points (1 control point): [p1, c2, p3, c4...]</summary>
    public static void DrawSplineBezierQuadratic(Vector2[] points, int pointCount, float thick, Color color)
    {
        fixed (Vector2* p = points)
        {
            DrawSplineBezierQuadratic(p, pointCount, thick, color);
        }
    }

    /// <summary>Draw spline: Cubic Bezier, minimum 4 points (2 control points): [p1, c2, c3, p4, c5, c6...]</summary>
    public static void DrawSplineBezierCubic(Vector2[] points, int pointCount, float thick, Color color)
    {
        fixed (Vector2* p = points)
        {
            DrawSplineBezierCubic(p, pointCount, thick, color);
        }
    }

    /// <summary>Draw a triangle strip defined by points</summary>
    public static void DrawTriangleStrip3D(Vector3[] points, int pointCount, Color color)
    {
        fixed (Vector3* p = points)
        {
            DrawTriangleStrip3D(p, pointCount, color);
        }
    }

    /// <summary>Draw multiple mesh instances with material and different transforms</summary>
    public static void DrawMeshInstanced(Mesh mesh, Material material, Matrix4x4[] transforms, int instances)
    {
        fixed (Matrix4x4* p = transforms)
        {
            DrawMeshInstanced(mesh, material, p, instances);
        }
    }

    /// <summary>
    /// Attach audio stream processor to the entire audio pipeline
    /// </summary>
    public static void AttachAudioMixedProcessor(AudioCallback<float> processor)
    {
        if (AudioMixed.Callback == null)
        {
            AudioMixed.Callback = processor;
            AttachAudioMixedProcessor(&AudioMixed.Processor);
        }
    }

    /// <summary>
    /// Detach audio stream processor from the entire audio pipeline
    /// </summary>
    public static void DetachAudioMixedProcessor(AudioCallback<float> processor)
    {
        if (AudioMixed.Callback == processor)
        {
            DetachAudioMixedProcessor(&AudioMixed.Processor);
            AudioMixed.Callback = null;
        }
    }

    public static string SubText(this string input, int position, int length)
    {
        return input.Substring(position, Math.Min(length, input.Length));
    }

    public static Material GetMaterial(ref Model model, int materialIndex)
    {
        return model.Materials[materialIndex];
    }

    public static Texture2D GetMaterialTexture(ref Model model, int materialIndex, MaterialMapIndex mapIndex)
    {
        return model.Materials[materialIndex].Maps[(int)mapIndex].Texture;
    }

    public static void SetMaterialTexture(
        ref Model model,
        int materialIndex,
        MaterialMapIndex mapIndex,
        ref Texture2D texture
    )
    {
        SetMaterialTexture(&model.Materials[materialIndex], mapIndex, texture);
    }

    public static void SetMaterialShader(ref Model model, int materialIndex, ref Shader shader)
    {
        model.Materials[materialIndex].Shader = shader;
    }
}
