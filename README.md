# LocationWeatherAPI


Create Location:

<b>POST</b> /api/location?Zipcode=90505&Name=My House&Country=United States of America&State=California&Id=6

<ul>
  <li>
will throw exception if zipcode already exists in db (zipcode column has a unique constraint)</li>
</ul>

Delete Location:
<b>DELETE</b> /api/location?Zipcode=90505&Name=My House&Country=United States of America&State=California&Id=6
<ul><li>uses ID field to delete</li>
</ul>
Get Location:
GET /api/location?Id=6

Get Weather:
GET /api/weather?Zipcode=90505&Name=My House&Country=United States of America&State=California&Id=6
OpenWeather 3rd party api provides weather data
uses zipcode to get weather
weather data is stored in a redis cache on azure with the zipcode as the key. 
if the same zipcode is requested within a 5 minute period weather data from the cache is returned and no api request is made to OpenWeather

Some other notes:
Endpoints are asynchronous
Used Simple Injector library to help with dependancy injection



