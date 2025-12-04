import { Routes } from '@angular/router';
import { Registration } from './components/registration/registration';
import { NotFound } from './components/not-found/not-found';
import { Vehicles } from './components/vehicles/vehicles';

export const routes: Routes = [
    {
        path:'',
        component: Vehicles,
        title:'My Cars'
    },
    {
        path:'registration/:vehicle-id',
        component: Registration,
        title: 'Registrations'
    },
    { path: '**', component: NotFound }
];
