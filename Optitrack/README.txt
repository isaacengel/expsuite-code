To compile the Motive OSC streamer executable:
1. Open the Visual Studio solution "MotiveOscStreamerLegacy\samples\MotiveOscStreamer-FIXED\vc2013\MotiveOscStreamer.sln" and compile in Release mode (tested with VS2019).
2. The executable will be generated as "MotiveOscStreamerLegacy\samples\MotiveOscStreamer-FIXED\vc2013\x64\Release\MotiveOscStreamer.exe"

To allow AMTatARI to access the cameras, put the following files in "AMTatARI files\Optitrack":
1. MotiveOscStreamer.exe (generated as described above)
2. NPTrackingToolsx64.dll (provided in this folder)
3. 14CamerasSetup.ttp (or the most recent Motive project)

Other utilities:
1. StartMotiveOscStreamer.bat: to launch the software manually
2. ExampleReadOSC.maxpat: Max patcher showing an example of how to read the OSC data