docker build . -t 542153354/pds:v3.0

docker login -u 542153354 -p 931592457cz

docker push 542153354/pds:v3.0
# docker run -d -p 8366:80 --restart=always pds:v2.0 
pause