# See: http://igoro.com/archive/self-printing-game-of-life-in-c/
$env:Path += ";C:\Program Files\dotnet\sdk\6.0.402\Roslyn\bincore"
csc.exe life.cs && (life > life.cs) && life