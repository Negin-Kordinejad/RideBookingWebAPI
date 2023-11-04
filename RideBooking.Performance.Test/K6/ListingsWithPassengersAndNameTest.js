import http from 'k6/http';

export function LoadTestFivePassengersAndName(){
     http.get("https://localhost:7190/Listings/5?name=suv");
}