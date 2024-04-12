﻿// Copyright (c) Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Runtime.InteropServices.Marshalling;
using Vortice.Mathematics;
using Vortice.DXGI;

#if WINDOWS
using WinRT;
using Microsoft.UI.Xaml.Media.Imaging;
#endif

namespace Vortice.WinUI;


[Guid("e4cecd6c-f14b-4f46-83c3-8bbda27c6504")]
public unsafe class ISurfaceImageSourceNative : SharpGen.Runtime.ComObject
{
    public ISurfaceImageSourceNative(IntPtr nativePtr)
        : base(nativePtr)
    {
    }

    public static explicit operator ISurfaceImageSourceNative?(IntPtr nativePtr)
    {
        return (nativePtr == IntPtr.Zero) ? null : new ISurfaceImageSourceNative(nativePtr);
    }

#if WINDOWS
    public ISurfaceImageSourceNative(SurfaceImageSource owner)
        : base(((IWinRTObject)owner).NativeObject.GetRef())
    {
    }

    public static explicit operator ISurfaceImageSourceNative(SurfaceImageSource owner) => new(owner);
#endif

    public IDXGIDevice Device
    {
        set => SetDevice(value).CheckError();
    }

    public Result SetDevice(IDXGIDevice device)
    {
        IntPtr devicePtr = MarshallingHelpers.ToCallbackPtr<IDXGIDevice>(device);
        Result result = ((delegate* unmanaged[Stdcall]<IntPtr, void*, int>)this[3])(NativePointer, (void*)devicePtr);
        GC.KeepAlive(device);
        result.CheckError();
        return result;
    }

    public Result BeginDraw(in RectI updateRect, out IDXGISurface? surface, out Int2 offset)
    {
        RawRect updateRectRaw = updateRect;
        IntPtr surfacePtr = IntPtr.Zero;
        offset = default;

        Result result;
        fixed (Int2* offsetPtr = &offset)
        {
            result = ((delegate* unmanaged<IntPtr, RawRect, void*, Int2*, int>)this[4])(NativePointer, updateRectRaw, &surfacePtr, offsetPtr);
        }

        surface = surfacePtr != IntPtr.Zero ? new IDXGISurface(surfacePtr) : null;
        return result;
    }

    public Result EndDraw()
    {
        Result result = ((delegate* unmanaged<IntPtr, int>)this[5])(NativePointer);
        return result;
    }
}
