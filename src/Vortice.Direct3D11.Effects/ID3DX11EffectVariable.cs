// Copyright (c) 2010-2014 Vortice - Alexandre Mutel
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
using System;

namespace Vortice.Direct3D11.Effects;

public partial class ID3DX11EffectVariable
{
    /// <summary>
    /// Set data.
    /// </summary>
    /// <param name="data">A reference to the variable.</param>
    /// <param name="count">size in bytes of data to write.</param>
    /// <returns>
    /// Returns one of the following {{Direct3D 10 Return Codes}}.
    /// </returns>
    /// <remarks>
    /// This method does no conversion or type checking; it is therefore a very quick way to access array items.
    /// </remarks>
    /// <unmanaged>HRESULT ID3D11EffectVariable::SetRawValue([None] void* pData,[None] int Offset,[None] int Count)</unmanaged>
    public void SetRawValue(DataStream data, int count)
    {
        SetRawValue(data.PositionPointer, 0, count);
    }

}
