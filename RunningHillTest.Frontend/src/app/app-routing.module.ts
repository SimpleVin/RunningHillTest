import { NgModule } from '@angular/core';
import { RouterModule, Routes,provideRouter  } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [
  // { path: '', redirectTo: '/app-component',  pathMatch: 'full'  },
  // { path: '/app-component', component: AppComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
