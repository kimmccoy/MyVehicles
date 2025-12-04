import { Component, inject, model, signal } from '@angular/core';
import { VehicleSummary } from '../../../api';
import { toSignal } from '@angular/core/rxjs-interop';
import { VehicleService } from '../../services/vehicle-service';
import { MakeService } from '../../services/make-service';
import { FormsModule } from '@angular/forms';
import {RouterLink} from '@angular/router';

@Component({
  selector: 'app-vehicles',
  imports: [
    FormsModule,
    RouterLink
  ],
  templateUrl: './vehicles.html',
  styleUrl: './vehicles.scss',
})
export class Vehicles {

  /** Vehicle service for loading vehicles */
  private vehicleService = inject(VehicleService);

  /** Make service for loading list of vehicle makes */
  private makesService = inject(MakeService);

  /** Vehicles to display */
  public vehicles = this.vehicleService.vehicles;

  /** Vehicle makes to display */
  public makes = this.makesService.makes;

  /** The currently selected make */
  public selectedMake = model<string>();

  constructor(){
  }

  ngOnInit(){

    // Load the makes
    this.makesService.load();

    // Load the vehicles
    this.vehicleService.loadVehicles();

    this.selectedMake.subscribe(value=>{
      this.vehicleService.loadVehicles(value);
    });
  }


}
