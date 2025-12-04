
import { inject, Injectable } from '@angular/core';
import { signal } from '@angular/core';
import { MakeService as MakeServiceApiClient } from '../../api';

@Injectable({
  providedIn: 'root'
})
export class MakeService {

  /** api client for vehicle makes */
  private makeServiceApiClient = inject(MakeServiceApiClient);

  /** list of vehicle makes in alphabetical order */
  public makes = signal<string[]>([]);

  /**
   * Loads all known vehicle makes
   */
  public load() {

    // get make data from the server. Only get once as this will rarely change.
    if (this.makes.length == 0) {

      // TODO: wrap in a common way to retry and handle errors
      this.makeServiceApiClient.apiMakesGet()
        .subscribe({
          next: (value) => {
            this.makes.set(value);
          },
          error(err) {
            console.error(err);
          },
        }
        );
    }
  }

}
