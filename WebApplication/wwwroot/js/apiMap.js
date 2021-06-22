var greenIcon = new L.Icon({
    iconUrl: 'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-2x-green.png',
    shadowUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/0.7.7/images/marker-shadow.png',
    iconSize: [25, 41],
    iconAnchor: [12, 41],
    popupAnchor: [1, -34],
    shadowSize: [41, 41]
});

var mymap = L.map('mapid').setView([3, 3], 9);

L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoicGN1cXVlbXkiLCJhIjoiY2txNW82c3hlMGQxODJ2cW80a20wdXVhaCJ9.Xa-faAijdGvYFWDsKC-Zzw', {
    /*attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',*/
    maxZoom: 16,
    id: 'mapbox/streets-v11',
    tileSize: 512,
    zoomOffset: -1,
    accessToken: 'pk.eyJ1IjoicGN1cXVlbXkiLCJhIjoiY2txNW82c3hlMGQxODJ2cW80a20wdXVhaCJ9.Xa-faAijdGvYFWDsKC-Zzw'
}).addTo(mymap);

mymap.removeControl(mymap.zoomControl);

/*Partie dynamique client*/
var longitudeOffre = document.getElementById("Eleveurlongitude");
var latitudeOffre = document.getElementById("Eleveurlatitude");
var longitude = document.getElementById("longitude");
var latitude = document.getElementById("latitude");

latitude = parseFloat(latitude.value.replace(',', '.'))
longitude = parseFloat(longitude.value.replace(',', '.'))

if (!latitudeOffre || !latitudeOffre) {
    var littleton = L.marker([latitude, longitude], { icon: greenIcon }).bindPopup('Troupeau');
    var cities = L.layerGroup([littleton]).addTo(mymap);
} else {
    latitudeOffre = parseFloat(latitudeOffre.value.replace(',', '.'))
    longitudeOffre = parseFloat(longitudeOffre.value.replace(',', '.'))
    var littleton = L.marker([latitude, longitude], { icon: greenIcon }).bindPopup('Troupeau'),
        denver = L.marker([latitudeOffre, longitudeOffre]).bindPopup('Terrain');
    var cities = L.layerGroup([littleton, denver]).addTo(mymap);
}

/*placer la vue*/
mymap.panTo([latitude, longitude]);