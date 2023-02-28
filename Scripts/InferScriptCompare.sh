#!/bin/bash

command=$1
current_file=$2
previous_file=$3

"$command" "--report-current" "$current_file" "--report-previous" "$previous_file"
