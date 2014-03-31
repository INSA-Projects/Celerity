<?xml version="1.0" ?>
<MiddleVR>
    <Kernel LogLevel="2" EnableCrashHandler="0" Version="1.0.9.20121105" />
    <DeviceManager WandAxis="0" WandHorizontalAxis="0" WandHorizontalAxisScale="1" WandVerticalAxis="1" WandVerticalAxisScale="1" WandButtons="0" WandButton0="0" WandButton1="1" WandButton2="2" WandButton3="3" WandButton4="4" WandButton5="5">
        <Driver Type="vrDriverDirectInput" />
        <Driver Type="vrDriverVRPN">
            <Axis Address="WiiMote0@localhost" ChannelIndex="0" ChannelsNb="30" Name="WiiMote0Axis" />
            <Buttons Address="WiiMote0@localhost" ChannelIndex="0" ChannelsNb="20" Name="WiiMote0Button" />
        </Driver>
    </DeviceManager>
    <DisplayManager Fullscreen="1" WindowBorders="0" ShowMouseCursor="1" VSync="1" SaveRenderTarget="0">
        <Node3D Name="CenterNode" Parent="VRRootNode" Tracker="0" PositionLocal="0.000000,0.000000,0.000000" OrientationLocal="0.000000,0.000000,0.000000,1.000000" />
        <Node3D Name="personnage" Parent="CenterNode" Tracker="0" PositionLocal="0.000000,0.000000,0.000000" OrientationLocal="0.000000,0.000000,0.000000,1.000000" />
        <Camera Name="Camera1" Parent="personnage" Tracker="0" PositionLocal="0.000000,0.000000,1.200000" OrientationLocal="0.000000,0.000000,0.000000,1.000000" VerticalFOV="60" Near="0.1" Far="1000" Screen="0" ScreenDistance="1" UseViewportAspectRatio="1" AspectRatio="1.33333" />
        <Node3D Name="HandNode" Parent="personnage" Tracker="0" PositionLocal="0.000000,0.000000,0.000000" OrientationLocal="0.000000,0.000000,0.000000,1.000000" />
        <Node3D Name="HeadNode" Parent="personnage" Tracker="0" PositionLocal="0.000000,0.000000,0.000000" OrientationLocal="0.000000,0.000000,0.000000,1.000000" />
        <Viewport Name="Viewport0" Left="0" Top="0" Width="1920" Height="1080" Camera="Camera1" Stereo="0" StereoMode="0" CompressSideBySide="0" StereoInvertEyes="0" />
    </DisplayManager>
    <ClusterManager NVidiaSwapLock="0" DisableVSyncOnServer="1" ForceOpenGLConversion="0" BigBarrier="0" SimulateClusterLag="0" />
</MiddleVR>
