using System;
using Vortice.D3DCompiler;

namespace Vortice.Direct3D11.Effects;

public partial class ID3DX11Effect
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ID3DX11Effect"/> class.
    /// </summary>
    /// <param name="device">The device.</param>
    /// <param name="effectByteCode">The effect byte code.</param>
    /// <param name="fxFlags">Effect compile options</param>
    /// <param name="srcName">Name of the effect source file.</param>
    public unsafe ID3DX11Effect(Vortice.Direct3D11.ID3D11Device device, byte[] effectByteCode, EffectFlags fxFlags = EffectFlags.None, string srcName = "<unknown>")
    {
        fixed (void* ptr = effectByteCode)
            Effects.CreateEffectFromMemory((IntPtr)ptr, effectByteCode.Length, (int)fxFlags, device, this, srcName);
    }
}
