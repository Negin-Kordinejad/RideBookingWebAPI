import http from 'k6/http';
export {LoadTestTwoPassengers} from './ListingsWithPassengers.js';
export {LoadTestFivePassengersAndName} from './ListingsWithPassengersAndNameTest.js';

export const options ={
     scenarios:
     {
          Two_Passengers_scenario: {
               executor: "shared-iterations",
               exec:"LoadTestTwoPassengers",
               vus: 100,
               iterations: 200,
             },
          Five_Passengers_And_Name_scenario: {
               executor: "shared-iterations",
               exec: "LoadTestFivePassengersAndName",
               vus: 100,
               iterations: 200,
             }
     }
};
