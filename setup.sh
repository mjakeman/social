echo "Installing Dependencies"
echo " > gir.core"
git clone https://github.com/gircore/gir.core ext/gir.core --init --recursive
echo " > blueprint-compiler"
git clone https://gitlab.gnome.org/jwestman/blueprint-compiler.git ext/blueprint-compiler

echo "Generating Bindings"
pushd ext/gir.core/src
dotnet fsi GenerateLibs.fsx
popd

echo "Running dotnet restore"
dotnet restore

echo "Done! Run dotnet build to continue"