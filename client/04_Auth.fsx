#r "nuget: FsHttp"

open System
open FsHttp
open FsHttp.Operators

#load "./shared/jwt.fsx"
#load "./shared/vault.fsx"

// --------------------

let mkToken () =
    Jwt.encode
        Vault.localEnv.secKey
        Vault.localEnv.issuer
        "Ronald"
        [ "admin" ]

// I see, we've created a httpAuth client that has the token
let httpAuth () =
    http {
        AuthorizationBearer (mkToken ())
    }

// --------------------



% httpAuth () {
    DELETE "http://localhost:5000/cities/paris"
}

% http {
    GET "http://localhost:5000/cities"
    CacheControl "no-cache"
}

% http {
    GET "http://localhost:5000/cities/paris"    
}


