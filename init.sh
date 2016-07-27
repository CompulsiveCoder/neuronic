DIR=$PWD

echo "Initializing neuronic project"
echo "Dir: $PWD"

git submodule update --init --recursive

cd lib
sh get-libs.sh
cd $DIR

cd mod/gitdb-cs/
INIT_FILE="init.sh"
if [ ! -f "$INIT_FILE" ]; then
  echo "gitdb-cs init file not found: $PWD/$INIT_FILE. Did the submodule fail to clone?"
else
  echo "gitdb-cs submodule found"
  sh init.sh
fi

cd $DIR
