import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Brand } from 'src/app/model/brand';
import { Car } from 'src/app/model/car';
import { Color } from 'src/app/model/color';
import { BrandService } from 'src/app/services/brand.service';
import { CarService } from 'src/app/services/car.service';
import { ColorService } from 'src/app/services/color.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {
  cars: Car[] = [];
  dataLoaded = false;
  filterText = '';
  selectedBrandId: number = 0;
  selectedColorId: number = 0;
  brands: Brand[] = [];
  colors: Color[] = [];

  constructor(private carService: CarService,
    private activatedRoute: ActivatedRoute,
    private brandService: BrandService,
    private colorService: ColorService) { }

  ngOnInit(): void {
    this.getBrands();
    this.getColors();

    this.activatedRoute.params.subscribe(params => {
      if (params['id']) {
        this.getCarsByBrand(params['id']);
      }
      else {
        this.getCarDetails();
      }
    });
  }

  getCars() {
    this.carService.getCars().subscribe((response) => {
      this.cars = response.data;
      this.dataLoaded = true;
    });
  }

  getCarsByBrand(brandId: number) {
    if (brandId == 0) {
      this.getCarDetails();
    } else {
      this.carService.getCarDetailsByBrand(brandId).subscribe((response) => {
        this.cars = response.data;
      });
    }
  }


  getCarDetails() {
    this.carService.getCarDetails().subscribe((response) => {
      this.cars = response.data;
      this.dataLoaded = true;
    });
  }

  getBrands() {
    this.brandService.getBrands().subscribe((response) => {
      this.brands = response.data;
    });
  }

  getColors() {
    this.colorService.getColors().subscribe((response) => {
      this.colors = response.data;
    });
  }
}
