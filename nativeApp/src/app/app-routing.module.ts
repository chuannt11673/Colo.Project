import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./home/home.module').then(m => m.HomePageModule)
  },
  {
    path: '',
    loadChildren: () => import('./login/login.module').then(m => m.LoginPageModule)
  },
  {
    path: 'friend-request',
    loadChildren: () => import('./friend-request/friend-request.module').then( m => m.FriendRequestPageModule)
  },
  {
    path: 'user-info/:email',
    loadChildren: () => import('./user-info/user-info.module').then( m => m.UserInfoPageModule)
  },
  {
    path: 'add-friends',
    loadChildren: () => import('./add-friends/add-friends.module').then( m => m.AddFriendsPageModule)
  },
  {
    path: 'chat/:email',
    loadChildren: () => import('./chat/chat.module').then( m => m.ChatPageModule)
  },  {
    path: 'change-language',
    loadChildren: () => import('./change-language/change-language.module').then( m => m.ChangeLanguagePageModule)
  },

];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
