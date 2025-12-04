import { inject, Injectable } from '@angular/core';
import { signal } from '@angular/core';
import { VehicleService as VehicleServiceApiClient, VehicleSummary } from '../../api';
import { toSignal } from '@angular/core/rxjs-interop';

/**
 * Service for managing vehicle data. 
 * TODO: may be better as a service scoped to the component depending on what the use cases are
 */
@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  private vehicleServiceApiClient = inject(VehicleServiceApiClient);

  //public vehicles = toSignal(this.vehicleServiceApiClient.apiVehiclesGet());
  public vehicles = signal<VehicleSummary[]>([]);

  // The current vehicle shown to the user
  public currentVehicle = signal<VehicleSummary|null>(null);

  /**
   * Loads vehicles for the current user, optionally limited to the vehicle make.
   * @param make Make of the vehicle such as Toyota, Honda. Not case sensitive
   */
  public loadVehicles(make?: string) {

    // clear the current values
    this.vehicles.set([]);

    // get vehicle data from the server
    // TODO: wrap in a common way to retry and handle errors
    this.vehicleServiceApiClient.apiVehiclesGet(make)
      .subscribe({
        next: (value) => {
          this.vehicles.set(value);
        },
        error(err) {
          console.error(err);
        },
      }
      );

  }

    /**
   * Loads a particular vehicle
   * @param id of the vehicle
   */
  public loadVehicle(id: number) {

    // clear the current values
    this.currentVehicle.set(null);

    // get vehicle data from the server
    // TODO: wrap in a common way to retry and handle errors
    this.vehicleServiceApiClient.apiVehiclesIdGet(id)
      .subscribe({
        next: (value) => {
          this.currentVehicle.set(value);
        },
        error(err) {
          console.error(err);
        },
      }
      );

  }

}
