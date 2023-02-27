#!/bin/bash

command=$1
compiler=$2
path=$3

"$command" "--" "$compiler" "$path"
