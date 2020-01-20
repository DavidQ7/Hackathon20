import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LandingComponent } from './landing/landing.component';
import { MainComponent } from './main/main.component';
import { AuthGuard } from 'src/Guards/auth.guard';


const routes: Routes = [

  {path: 'about', component: LandingComponent},
  {path: '', component: MainComponent/*, canActivate: [AuthGuard]*/ },
  { path: '**', redirectTo: '/about'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
