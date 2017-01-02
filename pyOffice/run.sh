#!/bin/bash

echo "Yo man! This will run your docker command!"

docker run -itd -v ~/src/officehours/:/src --name officehours tripdubroot/python