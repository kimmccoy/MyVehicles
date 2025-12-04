import { Component, computed, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { VehicleService } from '../../services/vehicle-service';
import { RegoClientService } from '../../services/rego-client-service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

/**
 * Shows registration details for a vehicle
 */
@Component({
  selector: 'app-registration',
  imports: [],
  templateUrl: './registration.html',
  styleUrl: './registration.scss',
})
export class Registration {

  private route = inject(ActivatedRoute);

  /** Vehicle service for loading vehicles */
  private vehicleService = inject(VehicleService);

  /** SignalR client for the rego check hub */
  private regoClientService = inject(RegoClientService);

  /** The latest registration recieved from the hub */
  public registrationStatus = computed<RegistrationStatus>(() => {
    const rego = this.regoClientService.regoDetailUpdate();

    if (rego && rego.vehicleId === this.vehicleId) {
      return rego.isExpired === true ? 'Expired' : 'Current';
    } else {
      return 'Unknown';
    }
  });


  /** The current vehicle */
  public vehicle = this.vehicleService.currentVehicle;

  /** Vehicle id when the page is loaded */
  private vehicleId: number;

  constructor() {
    // Get the id as a valid int
    const id = parseInt(this.route.snapshot.paramMap.get('vehicle-id') ?? '', 10);
    if (id > 0) {
      this.vehicleId = id;
    } else {
      // TODO: show an error or redirect to not found etc
      this.vehicleId = 0;
    }

    // get the rego status via signalr if the client is connected to the hub
    this.regoClientService.isConnectedNotifier.pipe(takeUntilDestroyed()).subscribe({
      next: data => {
        if (data === true) {
          // signal r is connected
            this.updateRegistrationStatus();
        }
      }
    });

  }


  ngOnInit() {

    // Load the vehicle
    if (this.vehicleId > 0) {
      this.vehicleService.loadVehicle(this.vehicleId);

      // Update the rego status. The hub may be connected already
      this.updateRegistrationStatus();
    }

  }

  /** Load the registration status of the vehical via call to a signalr hub */
  private updateRegistrationStatus() {
    // Load the vehicle
    if (this.vehicleId > 0) {
      if (this.regoClientService.isConnectedNotifier.value === true) {
        this.regoClientService.regoStatusInquiry(this.vehicleId);
      }
    }
  }



}

/** Status of a vehicle registration */
export type RegistrationStatus = 'Unknown' | 'Current' | 'Expired';

