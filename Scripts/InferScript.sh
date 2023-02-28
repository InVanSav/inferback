#!/bin/bash

command=$1
compiler=$2
path=$3

"$command" "--" "$compiler" "$path"

"cp" "/home/savickij_ivan/RiderProjects/inferback/inferback/infer-out/report.json" \
"/home/savickij_ivan/RiderProjects/inferback/previous.json"
