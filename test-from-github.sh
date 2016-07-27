echo "Testing project from github"
echo "  Current directory:"
echo "  $PWD"

BRANCH=$1

if [ -z "$BRANCH" ]; then
    BRANCH=$(git branch | sed -n -e 's/^\* \(.*\)/\1/p')
fi

if [ -z "$BRANCH" ]; then
    BRANCH="master"
fi

echo "  Branch: $BRANCH"

if [ -d ".tmp/neuronic" ]; then
    rm .tmp/neuronic -rf
fi

DIR=$PWD

git clone https://github.com/CompulsiveCoder/neuronic.git .tmp/neuronic --branch $BRANCH
cd .tmp/neuronic && \
sh init-build-test.sh && \
cd $DIR && \
rm .tmp/neuronic -rf
