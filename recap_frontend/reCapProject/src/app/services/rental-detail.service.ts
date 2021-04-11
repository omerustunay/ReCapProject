import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../model/car';
import { ListResponseModel } from '../model/listResponseModel';
import { RentalDetail } from '../model/rentalDetail';
import { ResponseModel } from '../model/responseModel';

@Injectable({
  providedIn: 'root'
})
export class RentalDetailService {

  apiUrl = 'https://localhost:44304/api/';
  constructor(private httpClient: HttpClient) { }

  getRentalDetails(): Observable<ListResponseModel<RentalDetail>> {
    let newPath = this.apiUrl + "rentals/getrentaldetails";
    return this.httpClient.get<ListResponseModel<RentalDetail>>(newPath);
  }
  getCarAllDetailByCarId(carId:number):Observable<ListResponseModel<RentalDetail>>{
    let path=this.apiUrl+ "rentals/getrentaldetailsbycarid?id=" + carId;
    return this.httpClient.get<ListResponseModel<RentalDetail>>(path);
  }
  getCheckCarReturnDate(carId:number):Observable<ListResponseModel<ResponseModel>>{
    let path=this.apiUrl+ "rentals/getcheckcarreturndate?carId=" + carId;
    return this.httpClient.get<ListResponseModel<ResponseModel>>(path);
  }

}
