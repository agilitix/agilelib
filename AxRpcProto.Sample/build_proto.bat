
@echo off

set PROTOC="%~1\packages\Grpc.Tools.1.7.3\tools\windows_x64\protoc.exe"
set PLUGIN="%~1\packages\Grpc.Tools.1.7.3\tools\windows_x64\grpc_csharp_plugin.exe"
set OUT_DIR="%~2"
set PROTO_FILE="%~3"

if not exist %OUT_DIR% (mkdir %OUT_DIR%)

%PROTOC% -I. --csharp_out %OUT_DIR% --grpc_out %OUT_DIR% %PROTO_FILE% --plugin=protoc-gen-grpc=%PLUGIN%
