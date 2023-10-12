Note that the Basler.Pylon .DLL is the only .NET assy here. It's copied to the output folder automatically because it is a dependency.

The rest are all dependencies required by the Basler.Pylon.DLL needs to run. 

They are copied to the application root folder via a post build event.

xcopy "$(TargetDir)\SupportFiles\BaslerDLLs" "$(TargetDir)"  /s /e /h /Y
