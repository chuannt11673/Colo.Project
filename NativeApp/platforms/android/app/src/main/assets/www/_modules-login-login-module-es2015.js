(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["_modules-login-login-module"],{

/***/ "./node_modules/raw-loader/dist/cjs.js!./src/app/_modules/login/login-entry/login-entry.component.html":
/*!*************************************************************************************************************!*\
  !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/_modules/login/login-entry/login-entry.component.html ***!
  \*************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<ion-content fullscreen class=\"ion-padding\" scroll-y=\"false\">\r\n    <ion-slides mode=\"ios\" pager=\"true\">\r\n        <ion-slide>\r\n            <div class=\"slide\">\r\n                <img src=\"/assets/images/slide-1.png\" />\r\n                <h2>Welcome</h2>\r\n                <p>The <b>ionic conference app</b> is a practical preview of the ionic framework in action, and a demonstration of proper code use.</p>\r\n            </div>\r\n        </ion-slide>\r\n        <ion-slide>\r\n            <img src=\"/assets/images/slide-2.png\" />\r\n            <h2>What is Ionic?</h2>\r\n            <p><b>Ionic Framework</b> is an open source SDK that enables developers to build high quality mobile apps with web technologies like HTML, CSS, and JavaScript.</p>\r\n        </ion-slide>\r\n        <ion-slide>\r\n            <img src=\"/assets/images/slide-3.png\" />\r\n            <h2>What is Ionic Appflow?</h2>\r\n            <p><b>Ionic Appflow</b> is a powerful set of services and features built on top of Ionic Framework that brings a totally new level of app development agility to mobile dev teams.</p>\r\n        </ion-slide>\r\n        <ion-slide>\r\n            <img src=\"/assets/images/slide-4.png\" />\r\n            <h2>Ready to Play?</h2>\r\n        </ion-slide>\r\n    </ion-slides>\r\n    <ion-toolbar>\r\n        <ion-button color=\"primary\" expand=\"full\" shape=\"round\" (click)=\"logIn()\">LOGIN</ion-button>\r\n        <ion-button color=\"light\" expand=\"full\" shape=\"round\">REGISTER</ion-button>\r\n    </ion-toolbar>\r\n</ion-content>\r\n<ion-footer class=\"ion-no-border\">\r\n    <ion-toolbar>\r\n        <div class=\"language\">\r\n            <span>Tiếng Việt</span>\r\n            <span>English</span>\r\n        </div>\r\n    </ion-toolbar>\r\n</ion-footer>");

/***/ }),

/***/ "./src/app/_modules/login/login-entry/login-entry.component.scss":
/*!***********************************************************************!*\
  !*** ./src/app/_modules/login/login-entry/login-entry.component.scss ***!
  \***********************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("ion-slides b {\n  font-weight: 500;\n}\nion-slides p {\n  padding: 0 40px;\n  font-size: 14px;\n  line-height: 1.5;\n  color: var(--ion-color-step-600, #60646b);\n}\nion-slides p b {\n  color: var(--ion-text-color, #000000);\n}\nion-slides .swiper-slide {\n  display: block;\n}\nion-slides .swiper-slide h2 {\n  margin-top: 2.8rem;\n}\nion-slides .swiper-slide img {\n  max-height: 50%;\n  max-width: 80%;\n  margin: 0;\n  pointer-events: none;\n}\nion-toolbar {\n  padding: 25px;\n}\nion-toolbar ion-button {\n  margin-top: 10px;\n}\ndiv.language {\n  display: flex;\n  justify-content: center;\n}\ndiv.language span {\n  padding: 10px;\n  text-align: center;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvX21vZHVsZXMvbG9naW4vbG9naW4tZW50cnkvQzpcXFByb2plY3RcXENvbG8uUHJvamVjdFxcTmF0aXZlQXBwL3NyY1xcYXBwXFxfbW9kdWxlc1xcbG9naW5cXGxvZ2luLWVudHJ5XFxsb2dpbi1lbnRyeS5jb21wb25lbnQuc2NzcyIsInNyYy9hcHAvX21vZHVsZXMvbG9naW4vbG9naW4tZW50cnkvbG9naW4tZW50cnkuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQ0k7RUFDSSxnQkFBQTtBQ0FSO0FERUk7RUFDSSxlQUFBO0VBQ0EsZUFBQTtFQUNBLGdCQUFBO0VBQ0EseUNBQUE7QUNBUjtBREVJO0VBQ0kscUNBQUE7QUNBUjtBREVJO0VBQ0ksY0FBQTtBQ0FSO0FERUk7RUFDSSxrQkFBQTtBQ0FSO0FERUk7RUFDSSxlQUFBO0VBQ0EsY0FBQTtFQUNBLFNBQUE7RUFDQSxvQkFBQTtBQ0FSO0FESUE7RUFDSSxhQUFBO0FDREo7QURFSTtFQUNJLGdCQUFBO0FDQVI7QURJQTtFQUNJLGFBQUE7RUFDQSx1QkFBQTtBQ0RKO0FERUk7RUFDSSxhQUFBO0VBQ0Esa0JBQUE7QUNBUiIsImZpbGUiOiJzcmMvYXBwL19tb2R1bGVzL2xvZ2luL2xvZ2luLWVudHJ5L2xvZ2luLWVudHJ5LmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiaW9uLXNsaWRlcyB7XHJcbiAgICBiIHtcclxuICAgICAgICBmb250LXdlaWdodDogNTAwO1xyXG4gICAgfVxyXG4gICAgcCB7XHJcbiAgICAgICAgcGFkZGluZzogMCA0MHB4O1xyXG4gICAgICAgIGZvbnQtc2l6ZTogMTRweDtcclxuICAgICAgICBsaW5lLWhlaWdodDogMS41O1xyXG4gICAgICAgIGNvbG9yOiB2YXIoLS1pb24tY29sb3Itc3RlcC02MDAsICM2MDY0NmIpO1xyXG4gICAgfVxyXG4gICAgcCBiIHtcclxuICAgICAgICBjb2xvcjogdmFyKC0taW9uLXRleHQtY29sb3IsICMwMDAwMDApO1xyXG4gICAgfVxyXG4gICAgLnN3aXBlci1zbGlkZSB7XHJcbiAgICAgICAgZGlzcGxheTogYmxvY2s7XHJcbiAgICB9XHJcbiAgICAuc3dpcGVyLXNsaWRlIGgyIHtcclxuICAgICAgICBtYXJnaW4tdG9wOiAyLjhyZW07XHJcbiAgICB9XHJcbiAgICAuc3dpcGVyLXNsaWRlIGltZyB7XHJcbiAgICAgICAgbWF4LWhlaWdodDogNTAlO1xyXG4gICAgICAgIG1heC13aWR0aDogODAlO1xyXG4gICAgICAgIG1hcmdpbjogMDtcclxuICAgICAgICBwb2ludGVyLWV2ZW50czogbm9uZTtcclxuICAgIH1cclxufVxyXG5cclxuaW9uLXRvb2xiYXIge1xyXG4gICAgcGFkZGluZzogMjVweDtcclxuICAgIGlvbi1idXR0b24ge1xyXG4gICAgICAgIG1hcmdpbi10b3A6IDEwcHg7XHJcbiAgICB9XHJcbn1cclxuXHJcbmRpdi5sYW5ndWFnZSB7XHJcbiAgICBkaXNwbGF5OiBmbGV4O1xyXG4gICAganVzdGlmeS1jb250ZW50OiBjZW50ZXI7XHJcbiAgICBzcGFuIHtcclxuICAgICAgICBwYWRkaW5nOiAxMHB4O1xyXG4gICAgICAgIHRleHQtYWxpZ246IGNlbnRlcjtcclxuICAgIH1cclxufSIsImlvbi1zbGlkZXMgYiB7XG4gIGZvbnQtd2VpZ2h0OiA1MDA7XG59XG5pb24tc2xpZGVzIHAge1xuICBwYWRkaW5nOiAwIDQwcHg7XG4gIGZvbnQtc2l6ZTogMTRweDtcbiAgbGluZS1oZWlnaHQ6IDEuNTtcbiAgY29sb3I6IHZhcigtLWlvbi1jb2xvci1zdGVwLTYwMCwgIzYwNjQ2Yik7XG59XG5pb24tc2xpZGVzIHAgYiB7XG4gIGNvbG9yOiB2YXIoLS1pb24tdGV4dC1jb2xvciwgIzAwMDAwMCk7XG59XG5pb24tc2xpZGVzIC5zd2lwZXItc2xpZGUge1xuICBkaXNwbGF5OiBibG9jaztcbn1cbmlvbi1zbGlkZXMgLnN3aXBlci1zbGlkZSBoMiB7XG4gIG1hcmdpbi10b3A6IDIuOHJlbTtcbn1cbmlvbi1zbGlkZXMgLnN3aXBlci1zbGlkZSBpbWcge1xuICBtYXgtaGVpZ2h0OiA1MCU7XG4gIG1heC13aWR0aDogODAlO1xuICBtYXJnaW46IDA7XG4gIHBvaW50ZXItZXZlbnRzOiBub25lO1xufVxuXG5pb24tdG9vbGJhciB7XG4gIHBhZGRpbmc6IDI1cHg7XG59XG5pb24tdG9vbGJhciBpb24tYnV0dG9uIHtcbiAgbWFyZ2luLXRvcDogMTBweDtcbn1cblxuZGl2Lmxhbmd1YWdlIHtcbiAgZGlzcGxheTogZmxleDtcbiAganVzdGlmeS1jb250ZW50OiBjZW50ZXI7XG59XG5kaXYubGFuZ3VhZ2Ugc3BhbiB7XG4gIHBhZGRpbmc6IDEwcHg7XG4gIHRleHQtYWxpZ246IGNlbnRlcjtcbn0iXX0= */");

/***/ }),

/***/ "./src/app/_modules/login/login-entry/login-entry.component.ts":
/*!*********************************************************************!*\
  !*** ./src/app/_modules/login/login-entry/login-entry.component.ts ***!
  \*********************************************************************/
/*! exports provided: LoginEntryComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LoginEntryComponent", function() { return LoginEntryComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _core_services_auth_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./../../../_core/services/auth.service */ "./src/app/_core/services/auth.service.ts");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");



let LoginEntryComponent = class LoginEntryComponent {
    constructor(authService) {
        this.authService = authService;
    }
    ngOnInit() {
        this.authService.completeSignOut();
    }
    logIn() {
        this.authService.startAuthentication();
    }
};
LoginEntryComponent.ctorParameters = () => [
    { type: _core_services_auth_service__WEBPACK_IMPORTED_MODULE_1__["AuthService"] }
];
LoginEntryComponent = Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"])([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
        selector: 'app-login-entry',
        template: Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"])(__webpack_require__(/*! raw-loader!./login-entry.component.html */ "./node_modules/raw-loader/dist/cjs.js!./src/app/_modules/login/login-entry/login-entry.component.html")).default,
        styles: [Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"])(__webpack_require__(/*! ./login-entry.component.scss */ "./src/app/_modules/login/login-entry/login-entry.component.scss")).default]
    })
], LoginEntryComponent);



/***/ }),

/***/ "./src/app/_modules/login/login.module.ts":
/*!************************************************!*\
  !*** ./src/app/_modules/login/login.module.ts ***!
  \************************************************/
/*! exports provided: LoginModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LoginModule", function() { return LoginModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _ionic_angular__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @ionic/angular */ "./node_modules/@ionic/angular/__ivy_ngcc__/fesm2015/ionic-angular.js");
/* harmony import */ var _auth_callback_auth_callback_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./auth-callback/auth-callback.component */ "./src/app/_modules/login/auth-callback/auth-callback.component.ts");
/* harmony import */ var _login_entry_login_entry_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./login-entry/login-entry.component */ "./src/app/_modules/login/login-entry/login-entry.component.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/__ivy_ngcc__/fesm2015/router.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm2015/core.js");






const routes = [
    {
        path: 'login',
        component: _login_entry_login_entry_component__WEBPACK_IMPORTED_MODULE_3__["LoginEntryComponent"],
    },
    {
        path: 'auth-callback',
        component: _auth_callback_auth_callback_component__WEBPACK_IMPORTED_MODULE_2__["AuthCallbackComponent"]
    },
    {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
    }
];
let LoginModule = class LoginModule {
};
LoginModule = Object(tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"])([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_5__["NgModule"])({
        imports: [
            _ionic_angular__WEBPACK_IMPORTED_MODULE_1__["IonicModule"],
            _angular_router__WEBPACK_IMPORTED_MODULE_4__["RouterModule"].forChild(routes),
        ],
        providers: []
    })
], LoginModule);



/***/ })

}]);
//# sourceMappingURL=_modules-login-login-module-es2015.js.map