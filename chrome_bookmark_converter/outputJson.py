from HTMLParser import HTMLParser

filename = "bookmarks_10_13_16.html"
text = open(filename)
data = text.read()

# create a subclass and override the handler methods
class MyHTMLParser(HTMLParser):
    def handle_starttag(self, tag, attrs):
        if len(attrs) != 0:
            print "Encountered a attribute:", attrs

    def handle_data(self, data):
        if data != '\r\n':
            if data != '\r\n ':
                print "Encountered some data  :", data

# instantiate the parser and fed it some HTML
parser = MyHTMLParser()
parser.feed(data)