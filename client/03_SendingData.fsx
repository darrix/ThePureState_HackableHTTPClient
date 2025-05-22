#r "nuget: FsHttp"

open System
open FsHttp
open FsHttp.Operators

// --------------------

% http {
    GET "http://localhost:5000/cities/frankfurt/currentConditions"
    CacheControl "no-cache"
}

% http {
    PUT "http://localhost:5000/cities/frankfurt/currentConditions"
    body
    json $$"""
        {
            "tempCelsius": 20.0,
            "humidity": 0.5
        }
    """
}

% http {
    PUT "http://localhost:5000/cities/frankfurt/currentConditions"
    body
    jsonSerialize (
        {|  tempCelsius = 20.0
            humidity = 0.5
        |}
    )
}

type CurrentConditions =
    {
        tempCelsius: float
        humidity: float
    }

let getCurrentConditions (cityName: string) =
    % http {
        GET $"http://localhost:5000/cities/{cityName}/currentConditions"
    }
    |> Response.deserializeJson<CurrentConditions>

getCurrentConditions "frankfurt"

let setCurrentConditions (cityName: string) (currentConditions: CurrentConditions) =
    % http {
        PUT $"http://localhost:5000/cities/{cityName}/currentConditions"
        body
        jsonSerialize currentConditions
    }

setCurrentConditions "frankfurt" { tempCelsius = 10.0; humidity = 0.8 }

getCurrentConditions "frankfurt"
