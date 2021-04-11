import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Car } from 'src/app/model/car';
import { RentalDetail } from 'src/app/model/rentalDetail';
import { CarService } from 'src/app/services/car.service';
import { RentalDetailService } from 'src/app/services/rental-detail.service';

@Component({
  selector: 'app-cardetail',
  templateUrl: './cardetail.component.html',
  styleUrls: ['./cardetail.component.css']
})
export class CardetailComponent implements OnInit {

  cars: Car[] = [];
  rents: RentalDetail[] = [];
  isRentable: boolean;
  buttonClick: boolean = false;
  rentDate: Date = null;
  returnDate: Date = null;
  carPrice: Number = null;

  imageBasePath: string = 'https://localhost:44304/';

  defaultImage: string = "Images/GeosLogo.png";
  dataLoaded = false;

  constructor(
    private carService: CarService,
    private rentalService: RentalDetailService,
    private activatedRoute: ActivatedRoute,
    private toastrService: ToastrService
  ) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      if (params['carId']) {
        this.getcardetailbyid(params['carId']);
        this.CheckRentable(params['carId']);
      }
    });
  }

  getcardetailbyid(id: number) {
    this.rentalService.getCarAllDetailByCarId(id).subscribe((response) => {
      this.rents = response.data;
      this.dataLoaded = true;
    });
  }
  CheckRentable(carId: number) {
    this.rentalService.getCheckCarReturnDate(carId).subscribe((response) => {
      this.isRentable = response.success;
    })
  }
  addToCart(rent: RentalDetail) {
    this.toastrService.success("Araç kiralandı", rent.carName);
  }
}
