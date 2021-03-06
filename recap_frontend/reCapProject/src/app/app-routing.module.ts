import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarComponent } from './components/car/car.component';
import { CardetailComponent } from './components/cardetail/cardetail.component';

const routes: Routes = [
  { path: '', pathMatch: "full", component: CarComponent },
  { path: 'cars', component: CarComponent },
  { path: 'cars/brand/:id', component: CarComponent },
  { path: 'cars/car-detail/:carId', component: CardetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
