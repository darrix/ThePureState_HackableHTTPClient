#r "nuget: FsHttp"

open System
open FsHttp
open FsHttp.Operators

// --------------------

% http {
    GET "http://localhost:5000/cities"
    CacheControl "no-cache"
}

% http {
    GET "http://localhost:5000/cities/frankfurt/historicalWeather"
}

% http {
    PUT "http://localhost:5000/cities/frankfurt/currentConditions"
    body
    jsonSerialize
        {|
            temperature = 20.0
            humidity = 0.5
        |}
}
