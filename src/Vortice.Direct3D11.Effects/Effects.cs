// Copyright (c) 2010-2014 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace Vortice.Direct3D11.Effects;


#pragma warning disable 419
#pragma warning disable 1587
#pragma warning disable 1574


public partial class Effects
{
    /// <summary>	
    /// <p>Creates an effect from a binary effect or file.</p>	
    /// </summary>	
    /// <param name="dataRef"><dd>  <p>Blob of compiled effect data.</p> </dd></param>	
    /// <param name="dataLength"><dd>  <p>Length of the data blob.</p> </dd></param>	
    /// <param name="fXFlags"><dd>  <p>No effect flags exist. Set to zero.</p> </dd></param>	
    /// <param name="deviceRef"><dd>  <p>Pointer to the <strong><see cref="SharpDX.Direct3D11.Device"/></strong> on which to create Effect resources.</p> </dd></param>	
    /// <param name="effectOut"><dd>  <p>Address of the newly created <strong><see cref="SharpDX.Direct3D11.Effect"/></strong> interface.</p> </dd></param>	
    /// <param name="srcName">No documentation.</param>	
    /// <returns><p>The return value is one of the values listed in Direct3D 11 Return Codes.</p></returns>	
    /// <remarks>	
    /// <p><strong>Note</strong>??You must use Effects 11 source to build  your effects-type application. For more info about using Effects 11 source, see Differences Between Effects 10 and Effects 11.</p>	
    /// </remarks>	
    /// <msdn-id>ff476273</msdn-id>	
    /// <unmanaged>HRESULT D3DX11CreateEffectFromMemory([In, Buffer] const void* pData,[In] SIZE_T DataLength,[In] unsigned int FXFlags,[In] ID3D11Device* pDevice,[Out, Fast] ID3DX11Effect** ppEffect,[In, Optional] const char* srcName)</unmanaged>	
    /// <unmanaged-short>D3DX11CreateEffectFromMemory</unmanaged-short>	
    public static void CreateEffectFromMemory(System.IntPtr dataRef,
        PointerSize dataLength,
        int fXFlags,
        ID3D11Device deviceRef,
        ID3DX11Effect effectOut,
        string srcName)
    {
        unsafe
        {
            IntPtr srcName_ = Marshal.StringToHGlobalAnsi(srcName);

            Result __result__ = D3DX11CreateEffectFromMemory_11_1_x64(dataRef, dataLength, fXFlags, deviceRef.NativePointer, out IntPtr effectOut_, srcName_);
            ((ID3DX11Effect)effectOut).NativePointer = effectOut_;
            Marshal.FreeHGlobal(srcName_);
            __result__.CheckError();
        }
    }

    [DllImport("Effects11.dll", EntryPoint = "D3DX11CreateEffectFromMemory")]
    private static extern Result D3DX11CreateEffectFromMemory_11_1_x64(IntPtr dataPointer,
        IntPtr dataLength,
        int fxFlags,
        IntPtr devicePtr,
        out IntPtr effectOut,
        IntPtr srcName);
}
