#!/bin/bash

#    RetroKS  Copyright (C) 2022  Aptivi
#
#    This file is part of RetroKS
#
#    RetroKS is free software: you can redistribute it and/or modify
#    it under the terms of the GNU General Public License as published by
#    the Free Software Foundation, either version 3 of the License, or
#    (at your option) any later version.
#
#    RetroKS is distributed in the hope that it will be useful,
#    but WITHOUT ANY WARRANTY; without even the implied warranty of
#    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
#    GNU General Public License for more details.
#
#    You should have received a copy of the GNU General Public License
#    along with this program.  If not, see <https://www.gnu.org/licenses/>.

# This script builds KS and packs the artifacts. Use when you have MSBuild installed.
ksversion=$(cat version)
ksreleaseconf=$1
if [ -z $ksreleaseconf ]; then
	ksreleaseconf=Release
fi

# Check for dependencies
zippath=`which zip`
if [ ! $? == 0 ]; then
	echo zip is not found.
	exit 1
fi

# Pack binary
echo Packing binary...
cd "../RetroKS/bin/$ksreleaseconf/net6.0/" && "$zippath" -r /tmp/$ksversion-bin.zip . && cd -
if [ ! $? == 0 ]; then
	echo Packing failed.
	exit 1
fi

# Inform success
mv /tmp/$ksversion-bin.zip .
cp "../RetroKS/bin/$ksreleaseconf/net6.0/RetroKS.pdb" ./$ksversion.pdb
echo Build and pack successful.
exit 0
