#!/bin/bash

sudo docker pull 542153354/admin.serverrender:v3.0 

containerId="`sudo docker ps | grep "8866->80" | awk  '{print $1}'`"
echo "containerId:$containerId"
if [ -n "$containerId" ]
then
 sudo docker stop $containerId
 sudo docker rm $containerId
fi

sudo docker run -d -p 8866:80 --restart=always 542153354/admin.serverrender:v3.0 /bin/sh 
exit
