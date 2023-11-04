import http from 'k6/http';

export function LoadTestTwoPassengers (){
     http.get("https://localhost:7190/Listings/2");
}