FROM python

ADD . /src
WORKDIR /src

RUN pip install django=='1.8.10'
RUN python manage.py migrate

EXPOSE 8000

CMD ["python", "manage.py", "runserver"]