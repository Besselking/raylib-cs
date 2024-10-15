using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;

namespace Raylib_cs;

[SuppressUnmanagedCodeSecurity]
public static unsafe partial class Rlgl
{
    /// <summary>
    /// Used by DllImport to load the native library
    /// </summary>
    public const string NativeLibName = "raylib";

    public const int DEFAULT_BATCH_BUFFER_ELEMENTS = 8192;
    public const int DEFAULT_BATCH_BUFFERS = 1;
    public const int DEFAULT_BATCH_DRAWCALLS = 256;
    public const int MAX_BATCH_ACTIVE_TEXTURES = 4;
    public const int MAX_MATRIX_STACK_SIZE = 32;
    public const float CULL_DISTANCE_NEAR = 0.01f;
    public const float CULL_DISTANCE_FAR = 1000.0f;

    // Texture parameters (equivalent to OpenGL defines)
    public const int TEXTURE_WRAP_S = 0x2802;
    public const int TEXTURE_WRAP_T = 0x2803;
    public const int TEXTURE_MAG_FILTER = 0x2800;
    public const int TEXTURE_MIN_FILTER = 0x2801;

    public const int TEXTURE_FILTER_NEAREST = 0x2600;
    public const int TEXTURE_FILTER_LINEAR = 0x2601;
    public const int TEXTURE_FILTER_MIP_NEAREST = 0x2700;
    public const int TEXTURE_FILTER_NEAREST_MIP_LINEAR = 0x2702;
    public const int TEXTURE_FILTER_LINEAR_MIP_NEAREST = 0x2701;
    public const int TEXTURE_FILTER_MIP_LINEAR = 0x2703;
    public const int TEXTURE_FILTER_ANISOTROPIC = 0x3000;
    public const int TEXTURE_MIPMAP_BIAS_RATIO = 0x4000;

    public const int TEXTURE_WRAP_REPEAT = 0x2901;
    public const int TEXTURE_WRAP_CLAMP = 0x812F;
    public const int TEXTURE_WRAP_MIRROR_REPEAT = 0x8370;
    public const int TEXTURE_WRAP_MIRROR_CLAMP = 0x8742;

    // GL equivalent data types
    public const int UNSIGNED_BYTE = 0x1401;
    public const int FLOAT = 0x1406;

    // Buffer usage hint
    public const int STREAM_DRAW = 0x88E0;
    public const int STREAM_READ = 0x88E1;
    public const int STREAM_COPY = 0x88E2;
    public const int STATIC_DRAW = 0x88E4;
    public const int STATIC_READ = 0x88E5;
    public const int STATIC_COPY = 0x88E6;
    public const int DYNAMIC_DRAW = 0x88E8;
    public const int DYNAMIC_READ = 0x88E9;
    public const int DYNAMIC_COPY = 0x88EA;

    // GL blending factors
    public const int ZERO = 0;
    public const int ONE = 1;
    public const int SRC_COLOR = 0x0300;
    public const int ONE_MINUS_SRC_COLOR = 0x0301;
    public const int SRC_ALPHA = 0x0302;
    public const int ONE_MINUS_SRC_ALPHA = 0x0303;
    public const int DST_ALPHA = 0x0304;
    public const int ONE_MINUS_DST_ALPHA = 0x0305;
    public const int DST_COLOR = 0x0306;
    public const int ONE_MINUS_DST_COLOR = 0x0307;
    public const int SRC_ALPHA_SATURATE = 0x0308;
    public const int CONSTANT_COLOR = 0x8001;
    public const int ONE_MINUS_CONSTANT_COLOR = 0x8002;
    public const int CONSTANT_ALPHA = 0x8003;
    public const int ONE_MINUS_CONSTANT_ALPHA = 0x8004;

    // GL blending functions/equations
    public const int FUNC_ADD = 0x8006;
    public const int MIN = 0x8007;
    public const int MAX = 0x8008;
    public const int FUNC_SUBTRACT = 0x800A;
    public const int FUNC_REVERSE_SUBTRACT = 0x800B;
    public const int BLEND_EQUATION = 0x8009;
    public const int BLEND_EQUATION_RGB = 0x8009;
    public const int BLEND_EQUATION_ALPHA = 0x883D;
    public const int BLEND_DST_RGB = 0x80C8;
    public const int BLEND_SRC_RGB = 0x80C9;
    public const int BLEND_DST_ALPHA = 0x80CA;
    public const int BLEND_SRC_ALPHA = 0x80CB;
    public const int BLEND_COLOR = 0x8005;

    // ------------------------------------------------------------------------------------
    // Functions Declaration - Matrix operations
    // ------------------------------------------------------------------------------------

    /// <summary>Choose the current matrix to be transformed</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlMatrixMode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void MatrixMode(int mode);

    /// <inheritdoc cref="MatrixMode(int)"/>
    public static void MatrixMode(MatrixMode mode)
    {
        MatrixMode((int)mode);
    }

    /// <summary>Push the current matrix to stack</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlPushMatrix")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void PushMatrix();

    /// <summary>Pop lattest inserted matrix from stack</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlPopMatrix")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void PopMatrix();

    /// <summary>Reset current matrix to identity matrix</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlLoadIdentity")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void LoadIdentity();

    /// <summary>Multiply the current matrix by a translation matrix</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlTranslatef")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Translatef(float x, float y, float z);

    /// <summary>Multiply the current matrix by a rotation matrix</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlRotatef")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Rotatef(float angle, float x, float y, float z);

    /// <summary>Multiply the current matrix by a scaling matrix</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlScalef")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Scalef(float x, float y, float z);

    /// <summary>
    /// Multiply the current matrix by another matrix<br/>
    /// Current Matrix can be set via <see cref="MatrixMode(int)"/>
    /// </summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlMultMatrixf")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void MultMatrixf(float* matf);

    /// <inheritdoc cref="MultMatrixf(float*)"/>
    public static void MultMatrixf(Matrix4x4 matf)
    {
        Float16 f = Raymath.MatrixToFloatV(matf);
        MultMatrixf(f.v);
    }

    [LibraryImport(NativeLibName, EntryPoint = "rlFrustum")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Frustum(
        double left,
        double right,
        double bottom,
        double top,
        double znear,
        double zfar
    );

    [LibraryImport(NativeLibName, EntryPoint = "rlOrtho")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Ortho(
        double left,
        double right,
        double bottom,
        double top,
        double znear,
        double zfar
    );

    /// <summary>Set the viewport area</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlViewport")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Viewport(int x, int y, int width, int height);


    // ------------------------------------------------------------------------------------
    // Functions Declaration - Vertex level operations
    // ------------------------------------------------------------------------------------

    /// <summary>Initialize drawing mode (how to organize vertex)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlBegin")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Begin(int mode);

    public static void Begin(DrawMode mode)
    {
        Begin((int)mode);
    }

    /// <summary>Finish vertex providing</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnd")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void End();

    /// <summary>Define one vertex (position) - 2 int</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlVertex2i")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Vertex2i(int x, int y);

    /// <summary>Define one vertex (position) - 2 float</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlVertex2f")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Vertex2f(float x, float y);

    /// <summary>Define one vertex (position) - 3 float</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlVertex3f")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Vertex3f(float x, float y, float z);

    /// <summary>Define one vertex (texture coordinate) - 2 float</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlTexCoord2f")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void TexCoord2f(float x, float y);

    /// <summary>Define one vertex (normal) - 3 float</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlNormal3f")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Normal3f(float x, float y, float z);

    /// <summary>Define one vertex (color) - 4 byte</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlColor4ub")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Color4ub(byte r, byte g, byte b, byte a);

    /// <summary>Define one vertex (color) - 3 float</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlColor3f")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Color3f(float x, float y, float z);

    /// <summary>Define one vertex (color) - 4 float</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlColor4f")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Color4f(float x, float y, float z, float w);


    // ------------------------------------------------------------------------------------
    // Functions Declaration - OpenGL equivalent functions (common to 1.1, 3.3+, ES2)
    // NOTE: This functions are used to completely abstract raylib code from OpenGL layer
    // ------------------------------------------------------------------------------------

    /// <summary>Vertex buffers state</summary>

    /// <summary>Enable vertex array (VAO, if supported)</summary>
    [DllImport(NativeLibName, EntryPoint = "rlEnableVertexArray", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool EnableVertexArray(uint vaoId);

    /// <summary>Disable vertex array (VAO, if supported)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableVertexArray")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableVertexArray();

    /// <summary>Enable vertex buffer (VBO)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableVertexBuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableVertexBuffer(uint id);

    /// <summary>Disable vertex buffer (VBO)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableVertexBuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableVertexBuffer();

    /// <summary>Enable vertex buffer element (VBO element)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableVertexBufferElement")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableVertexBufferElement(uint id);

    /// <summary>Disable vertex buffer element (VBO element)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableVertexBufferElement")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableVertexBufferElement();

    /// <summary>Enable vertex attribute index</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableVertexAttribute")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableVertexAttribute(uint index);

    /// <summary>Disable vertex attribute index</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableVertexAttribute")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableVertexAttribute(uint index);

    /// <summary>Enable attribute state pointer<br/>
    /// NOTE: Only available for GRAPHICS_API_OPENGL_11</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableStatePointer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableStatePointer(int vertexAttribType, void* buffer);

    /// <summary>Disable attribute state pointer<br/>
    /// NOTE: Only available for GRAPHICS_API_OPENGL_11</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableStatePointer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableStatePointer(int vertexAttribType);


    // Textures state

    /// <summary>Select and active a texture slot</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlActiveTextureSlot")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void ActiveTextureSlot(int slot);

    /// <summary>Enable texture</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableTexture(uint id);

    /// <summary>Disable texture</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableTexture();

    /// <summary>Enable texture cubemap</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableTextureCubemap")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableTextureCubemap(uint id);

    /// <summary>Disable texture cubemap</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableTextureCubemap")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableTextureCubemap();

    /// <summary>Set texture parameters (filter, wrap)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlTextureParameters")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void TextureParameters(uint id, int param, int value);

    /// <summary>Set cubemap parameters (filter, wrap)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlCubemapParameters")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void CubemapParameters(uint id, int param, int value);


    // Shader state

    /// <summary>Enable shader program</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableShader")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableShader(uint id);

    /// <summary>Disable shader program</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableShader")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableShader();


    // Framebuffer state

    /// <summary>Enable render texture (fbo)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableFramebuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableFramebuffer(uint id);

    /// <summary>Disable render texture (fbo), return to default framebuffer</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableFramebuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableFramebuffer();

    /// <summary>Blit active framebuffer to main framebuffer</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlBlitFramebuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void BlitFramebuffer();

    /// <summary>Activate multiple draw color buffers</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlActiveDrawBuffers")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void ActiveDrawBuffers(int count);


    // General render state

    /// <summary>Enable color blending</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableColorBlend")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableColorBlend();

    /// <summary>Disable color blending</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableColorBlend")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableColorBlend();

    /// <summary>Enable depth test</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableDepthTest")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableDepthTest();

    /// <summary>Disable depth test</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableDepthTest")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableDepthTest();

    /// <summary>Enable depth write</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableDepthMask")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableDepthMask();

    /// <summary>Disable depth write</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableDepthMask")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableDepthMask();

    /// <summary>Enable backface culling</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableBackfaceCulling")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableBackfaceCulling();

    /// <summary>Disable backface culling</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableBackfaceCulling")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableBackfaceCulling();

    /// <summary>Set face culling mode</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlSetCullFace")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetCullFace(int mode);

    /// <summary>Enable scissor test</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableScissorTest")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableScissorTest();

    /// <summary>Disable scissor test</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableScissorTest")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableScissorTest();

    /// <summary>Scissor test</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlScissor")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Scissor(int x, int y, int width, int height);

    /// <summary>Enable wire mode</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableWireMode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableWireMode();

    /// <summary>Enable point mode</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnablePointMode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnablePointMode();

    /// <summary>Disable wire mode</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableWireMode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableWireMode();

    /// <summary>Set the line drawing width</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlSetLineWidth")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetLineWidth(float width);

    /// <summary>Get the line drawing width</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlGetLineWidth")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial float GetLineWidth();

    /// <summary>Enable line aliasing</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableSmoothLines")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableSmoothLines();

    /// <summary>Disable line aliasing</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableSmoothLines")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableSmoothLines();

    /// <summary>Enable stereo rendering</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlEnableStereoRender")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void EnableStereoRender();

    /// <summary>Disable stereo rendering</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDisableStereoRender")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DisableStereoRender();

    /// <summary>Check if stereo render is enabled</summary>
    [DllImport(NativeLibName, EntryPoint = "rlIsStereoRenderEnabled", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool IsStereoRenderEnabled();

    /// <summary>Clear color buffer with color</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlClearColor")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void ClearColor(byte r, byte g, byte b, byte a);

    /// <summary>Clear used screen buffers (color and depth)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlClearScreenBuffers")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void ClearScreenBuffers();

    /// <summary>Check and log OpenGL error codes</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlCheckErrors")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void CheckErrors();

    /// <summary>Set blending mode</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlSetBlendMode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetBlendMode(BlendMode mode);

    /// <summary>Set blending mode factor and equation (using OpenGL factors)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlSetBlendFactors")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetBlendFactors(int glSrcFactor, int glDstFactor, int glEquation);

    /// <summary>Set blending mode factors and equations separately (using OpenGL factors)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlSetBlendFactorsSeparate")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetBlendFactorsSeparate(
        int glSrcRGB,
        int glDstRGB,
        int glSrcAlpha,
        int glDstAlpha,
        int glEqRGB,
        int glEqAlpha
    );


    // ------------------------------------------------------------------------------------
    // Functions Declaration - rlgl functionality
    // ------------------------------------------------------------------------------------

    /// <summary>Initialize rlgl (buffers, shaders, textures, states)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlglInit")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void GlInit(int width, int height);

    /// <summary>De-inititialize rlgl (buffers, shaders, textures)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlglClose")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void GlClose();

    /// <summary>Load OpenGL extensions</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlLoadExtensions")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void LoadExtensions(void* loader);

    /// <summary>Get current OpenGL version</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlGetVersion")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial GlVersion GetVersion();

    /// <summary>Get default framebuffer width</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlGetFramebufferWidth")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int GetFramebufferWidth();

    /// <summary>Get default framebuffer height</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlGetFramebufferHeight")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int GetFramebufferHeight();

    /// <summary>Get default texture</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlGetTextureIdDefault")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint GetTextureIdDefault();

    /// <summary>Get default shader</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlGetShaderIdDefault")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint GetShaderIdDefault();

    /// <summary>Get default shader locations</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlGetShaderLocsDefault")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int* GetShaderLocsDefault();

    // Render batch management

    /// <summary>Load a render batch system<br/>
    /// NOTE: rlgl provides a default render batch to behave like OpenGL 1.1 immediate mode<br/>
    /// but this render batch API is exposed in case custom batches are required</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlLoadRenderBatch")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial RenderBatch LoadRenderBatch(int numBuffers, int bufferElements);

    /// <summary>Unload render batch system</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlUnloadRenderBatch")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UnloadRenderBatch(RenderBatch batch);

    /// <summary>Draw render batch data (Update->Draw->Reset)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDrawRenderBatch")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DrawRenderBatch(RenderBatch* batch);

    /// <summary>Set the active render batch for rlgl (NULL for default internal)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlSetRenderBatchActive")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetRenderBatchActive(RenderBatch* batch);

    /// <summary>Update and draw internal render batch</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlDrawRenderBatchActive")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DrawRenderBatchActive();

    /// <summary>Check internal buffer overflow for a given number of vertex</summary>
    [DllImport(NativeLibName, EntryPoint = "rlCheckRenderBatchLimit", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CheckRenderBatchLimit(int vCount);

    /// <summary>Set current texture for render batch and check buffers limits</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlSetTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetTexture(uint id);


    // Vertex buffers management

    /// <summary>Load vertex array (vao) if supported</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlLoadVertexArray")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint LoadVertexArray();

    /// <summary>Load a vertex buffer attribute</summary>
    [DllImport(NativeLibName, EntryPoint = "rlLoadVertexBuffer", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint LoadVertexBuffer(void* buffer, int size, bool dynamic);

    /// <summary>Load a new attributes element buffer</summary>
    [DllImport(NativeLibName, EntryPoint = "rlLoadVertexBufferElement", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint LoadVertexBufferElement(void* buffer, int size, bool dynamic);

    /// <summary>Update GPU buffer with new data</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlUpdateVertexBuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UpdateVertexBuffer(uint bufferId, void* data, int dataSize, int offset);

    /// <summary>Update vertex buffer elements with new data</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlUpdateVertexBufferElements")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UpdateVertexBufferElements(uint id, void* data, int dataSize, int offset);

    [LibraryImport(NativeLibName, EntryPoint = "rlUnloadVertexArray")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UnloadVertexArray(uint vaoId);

    [LibraryImport(NativeLibName, EntryPoint = "rlUnloadVertexBuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UnloadVertexBuffer(uint vboId);

    [DllImport(NativeLibName, EntryPoint = "rlSetVertexAttribute", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetVertexAttribute(
        uint index,
        int compSize,
        int type,
        bool normalized,
        int stride,
        void* pointer
    );

    [LibraryImport(NativeLibName, EntryPoint = "rlSetVertexAttributeDivisor")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetVertexAttributeDivisor(uint index, int divisor);

    /// <summary>Set vertex attribute default value</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlSetVertexAttributeDefault")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetVertexAttributeDefault(int locIndex, void* value, int attribType, int count);

    [LibraryImport(NativeLibName, EntryPoint = "rlDrawVertexArray")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DrawVertexArray(int offset, int count);

    [LibraryImport(NativeLibName, EntryPoint = "rlDrawVertexArrayElements")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DrawVertexArrayElements(int offset, int count, void* buffer);

    [LibraryImport(NativeLibName, EntryPoint = "rlDrawVertexArrayInstanced")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DrawVertexArrayInstanced(int offset, int count, int instances);

    [LibraryImport(NativeLibName, EntryPoint = "rlDrawVertexArrayElementsInstanced")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void DrawVertexArrayElementsInstanced(
        int offset,
        int count,
        void* buffer,
        int instances
    );


    // Textures data management

    /// <summary>Load texture in GPU</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlLoadTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint LoadTexture(void* data, int width, int height, PixelFormat format, int mipmapCount);

    /// <summary>Load depth texture/renderbuffer (to be attached to fbo)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlLoadTextureDepth")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint LoadTextureDepth(int width, int height, [MarshalAs(UnmanagedType.U1)] bool useRenderBuffer);

    /// <summary>Load texture cubemap</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlLoadTextureCubemap")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint LoadTextureCubemap(void* data, int size, PixelFormat format);

    /// <summary>Update GPU texture with new data</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlUpdateTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UpdateTexture(
        uint id,
        int offsetX,
        int offsetY,
        int width,
        int height,
        PixelFormat format,
        void* data
    );

    /// <summary>Get OpenGL internal formats</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlGetGlTextureFormats")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void GetGlTextureFormats(
        PixelFormat format,
        uint* glInternalFormat,
        uint* glFormat,
        uint* glType
    );

    /// <summary>Get OpenGL internal formats</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlGetPixelFormatName")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial sbyte* GetPixelFormatName(PixelFormat format);

    /// <summary>Unload texture from GPU memory</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlUnloadTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UnloadTexture(uint id);

    /// <summary>Generate mipmap data for selected texture</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlGenTextureMipmaps")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void GenTextureMipmaps(uint id, int width, int height, PixelFormat format, int* mipmaps);

    /// <summary>Read texture pixel data</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlReadTexturePixels")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void* ReadTexturePixels(uint id, int width, int height, PixelFormat format);

    /// <summary>Read screen pixel data (color buffer)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlReadScreenPixels")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial byte* ReadScreenPixels(int width, int height);


    // Framebuffer management (fbo)

    /// <summary>Load an empty framebuffer</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlLoadFramebuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint LoadFramebuffer(int width, int height);

    /// <summary>Attach texture/renderbuffer to a framebuffer</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlFramebufferAttach")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void FramebufferAttach(
        uint fboId,
        uint texId,
        FramebufferAttachType attachType,
        FramebufferAttachTextureType texType,
        int mipLevel
    );

    /// <summary>Verify framebuffer is complete</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlFramebufferComplete")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.U1)]
    public static partial bool FramebufferComplete(uint id);

    /// <summary>Delete framebuffer from GPU</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlUnloadFramebuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UnloadFramebuffer(uint id);


    // Shaders management

    /// <summary>Load shader from code strings</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlLoadShaderCode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint LoadShaderCode(sbyte* vsCode, sbyte* fsCode);

    /// <summary>Compile custom shader and return shader id<br/>
    /// (type: VERTEX_SHADER, FRAGMENT_SHADER, COMPUTE_SHADER)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlCompileShader")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint CompileShader(sbyte* shaderCode, int type);

    /// <summary>Load custom shader program</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlLoadShaderProgram")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint LoadShaderProgram(uint vShaderId, uint fShaderId);

    /// <summary>Unload shader program</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlUnloadShaderProgram")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UnloadShaderProgram(uint id);

    /// <summary>Get shader location uniform</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlGetLocationUniform")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int GetLocationUniform(uint shaderId, sbyte* uniformName);

    /// <summary>Get shader location attribute</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlGetLocationAttrib")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int GetLocationAttrib(uint shaderId, sbyte* attribName);

    /// <summary>Set shader value uniform</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlSetUniform")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetUniform(int locIndex, void* value, int uniformType, int count);

    /// <summary>Set shader value matrix</summary>
    [DllImport(NativeLibName, EntryPoint = "rlSetUniformMatrix", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetUniformMatrix(int locIndex, Matrix4x4 mat);

    /// <summary>Set shader value sampler</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlSetUniformSampler")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetUniformSampler(int locIndex, uint textureId);

    /// <summary>Set shader currently active (id and locations)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlSetShader")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetShader(uint id, int* locs);


    // Compute shader management

    /// <summary>Load compute shader program</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlLoadComputeShaderProgram")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint LoadComputeShaderProgram(uint shaderId);

    /// <summary>Dispatch compute shader (equivalent to *draw* for graphics pilepine)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlComputeShaderDispatch")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void ComputeShaderDispatch(uint groupX, uint groupY, uint groupZ);


    // Shader buffer storage object management (ssbo)

    /// <summary>Load shader storage buffer object (SSBO)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlLoadShaderBuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint LoadShaderBuffer(uint size, void* data, int usageHint);

    /// <summary>Unload shader storage buffer object (SSBO)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlUnloadShaderBuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UnloadShaderBuffer(uint ssboId);

    /// <summary>Update SSBO buffer data</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlUpdateShaderBuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UpdateShaderBuffer(uint id, void* data, uint dataSize, uint offset);

    /// <summary>Bind SSBO buffer data</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlBindShaderBuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void BindShaderBuffer(uint id, uint index);

    /// <summary>Read SSBO buffer data (GPU->CPU)</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlReadShaderBuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void ReadShaderBuffer(uint id, void* dest, uint count, uint offset);

    /// <summary>Copy SSBO data between buffers</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlCopyShaderBuffer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void CopyShaderBuffer(
        uint destId,
        uint srcId,
        uint destOffset,
        uint srcOffset,
        uint count
    );

    /// <summary>Get SSBO buffer size</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlGetShaderBufferSize")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint GetShaderBufferSize(uint id);


    // Buffer management

    /// <summary>Bind image texture</summary>
    [DllImport(NativeLibName, EntryPoint = "rlBindImageTexture", CallingConvention = CallingConvention.Cdecl)]
    public static extern void BindImageTexture(uint id, uint index, int format, bool readOnly);


    // Matrix state management

    /// <summary>Get internal modelview matrix</summary>
    [DllImport(NativeLibName, EntryPoint = "rlGetMatrixModelview", CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 GetMatrixModelview();

    /// <summary>Get internal projection matrix</summary>
    [DllImport(NativeLibName, EntryPoint = "rlGetMatrixProjection", CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 GetMatrixProjection();

    /// <summary>Get internal accumulated transform matrix</summary>
    [DllImport(NativeLibName, EntryPoint = "rlGetMatrixTransform", CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 GetMatrixTransform();

    /// <summary>Get internal projection matrix for stereo render (selected eye)</summary>
    [DllImport(NativeLibName, EntryPoint = "rlGetMatrixProjectionStereo", CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 GetMatrixProjectionStereo(int eye);

    /// <summary>Get internal view offset matrix for stereo render (selected eye)</summary>
    [DllImport(NativeLibName, EntryPoint = "rlGetMatrixViewOffsetStereo", CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 GetMatrixViewOffsetStereo(int eye);

    /// <summary>Set a custom projection matrix (replaces internal projection matrix)</summary>
    [DllImport(NativeLibName, EntryPoint = "rlSetMatrixProjection", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMatrixProjection(Matrix4x4 view);

    /// <summary>Set a custom modelview matrix (replaces internal modelview matrix)</summary>
    [DllImport(NativeLibName, EntryPoint = "rlSetMatrixModelview", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMatrixModelView(Matrix4x4 proj);

    /// <summary>Set eyes projection matrices for stereo rendering</summary>
    [DllImport(NativeLibName, EntryPoint = "rlSetMatrixProjectionStereo", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMatrixProjectionStereo(Matrix4x4 left, Matrix4x4 right);

    /// <summary>Set eyes view offsets matrices for stereo rendering</summary>
    [DllImport(NativeLibName, EntryPoint = "rlSetMatrixViewOffsetStereo", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMatrixViewOffsetStereo(Matrix4x4 left, Matrix4x4 right);


    // Quick and dirty cube/quad buffers load->draw->unload

    /// <summary>Load and draw a cube</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlLoadDrawCube")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void LoadDrawCube();

    /// <summary>Load and draw a quad</summary>
    [LibraryImport(NativeLibName, EntryPoint = "rlLoadDrawQuad")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void LoadDrawQuad();
}
