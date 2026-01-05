//? fect API worker to fetch data from a given URL
self.onmessage = function(){
    let xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            self.postMessage(this.responseText);
        }
    };
    xmlhttp.open("GET", 'https://jsonplaceholder.typicode.com/posts/1', true);
    xmlhttp.send();
}