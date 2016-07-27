echo "Starting build"
echo "Dir: $PWD"

DIR=$PWD

cd mod/gitdb-cs/
sh build.sh
cd $DIR

xbuild src/neuronic.sln /p:Configuration=Release
