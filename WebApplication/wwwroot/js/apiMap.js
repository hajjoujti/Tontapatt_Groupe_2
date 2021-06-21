let longitude = document.getElementById("longitude");
let latitude = document.getElementById("latitude");

console.log(latitude.value);
console.log(longitude.value);

latitude = parseFloat(latitude.value)
longitude = parseFloat(longitude.value)


const terrain = {
    lat: latitude,
    lng: longitude
}

var mymap = L.map('mapid').setView([3, 3], 13);

L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoicGN1cXVlbXkiLCJhIjoiY2txNW82c3hlMGQxODJ2cW80a20wdXVhaCJ9.Xa-faAijdGvYFWDsKC-Zzw', {
    /*attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',*/
    maxZoom: 13,
    id: 'mapbox/streets-v11',
    tileSize: 512,
    zoomOffset: -1, 
    accessToken: 'pk.eyJ1IjoicGN1cXVlbXkiLCJhIjoiY2txNW82c3hlMGQxODJ2cW80a20wdXVhaCJ9.Xa-faAijdGvYFWDsKC-Zzw'
}).addTo(mymap);

mymap.panTo([terrain.lat, terrain.lng]);
mymap.removeControl(mymap.zoomControl);

var marker = L.marker([terrain.lat, terrain.lng]).addTo(mymap)
