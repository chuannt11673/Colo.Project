import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePage } from './home.page';
import { AuthGuard } from '../_core/guards/auth-guard.service';
import { HomeResolver } from './home.resolver';

const routes: Routes = [
  {
    path: '',
    component: HomePage,
    resolve: [HomeResolver],
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
    children: [
      {
        path: '',
        redirectTo: 'message',
        pathMatch: 'full'
      },
      {
        path: 'message',
        loadChildren: () => import('./message/message.module').then( m => m.MessagePageModule)
      },
      {
        path: 'diary',
        loadChildren: () => import('./diary/diary.module').then( m => m.DiaryPageModule)
      },
      {
        path: 'friends',
        loadChildren: () => import('./friends/friends.module').then( m => m.FriendsPageModule)
      },
      {
        path: 'dating',
        loadChildren: () => import('./dating/dating.module').then( m => m.DatingPageModule)
      },
      {
        path: 'more',
        loadChildren: () => import('./more/more.module').then( m => m.MorePageModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  providers: [HomeResolver, AuthGuard],
  exports: [RouterModule]
})
export class HomePageRoutingModule {}
