import { Injectable, signal } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { RegistrationSummary } from '../../api';
import { BehaviorSubject } from 'rxjs';
import { environment } from '../../environments/environment';


/** SignalR client for the rego hub. Provides facility to check if a vehicle registration is valid */
@Injectable({
  providedIn: 'root'
})
export class RegoClientService {

  /** connection to the /hubs/rego hub */
  private hubConnection?: signalR.HubConnection;

  /** updates sent from the server with registration details */
  public regoDetailUpdate = signal<RegistrationSummary | undefined>(undefined)

  /** notifies when the hub is connection status changes */
  public isConnectedNotifier = new BehaviorSubject<boolean>(false);

  constructor() {
    this.connect();
  }


  /** Connect the signal r hub */
  private connect() {

    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${environment.apiBaseUrl}/hubs/rego`, {
        // TODO: using cookie authentication here so this is not needed
        //withCredentials: sessionStorage.getItem('token') != null,
        // accessTokenFactory: () => {
        //   let token = sessionStorage.getItem('token');
        //     return token ?? '';
        // },
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets,
      })
      .build();

    this.hubConnection
      .start()
      .then(
        () => {
          this.isConnectedNotifier.next(true);
          // TODO: log elsewhere - console for demo only
          console.log('Connected to SignalR hub');
        })
      .catch(err => {
        this.isConnectedNotifier.next(false);
        // TODO: log elsewhere - console for demo only
        console.error('Error connecting to SignalR hub:', err);
      });

      /** handle RegoDetailsUpdate message from the hub */
    this.hubConnection.on('RegoDetailUpdate', (data: RegistrationSummary) => {
      this.regoDetailUpdate.set(data);
    });
  }

  /** 
   * Send an inquiry to the server to get the expiry status of a vehicle registration 
   * @param vehicleId id of the vehicle (not the registration)
   * */
  async regoStatusInquiry(vehicleId: number) {
    await this.hubConnection?.invoke('RegoStatusInquiry', vehicleId);
  }



}
