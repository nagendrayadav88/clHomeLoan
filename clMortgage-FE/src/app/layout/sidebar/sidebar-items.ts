import { RouteInfo } from './sidebar.metadata';
export const ROUTES: RouteInfo[] = [
  {
    path: '',
    title: 'MENUITEMS.MAIN.TEXT',
    moduleName: '',
    iconType: '',
    icon: '',
    class: '',
    groupTitle: true,
    badge: '',
    badgeClass: '',
    role: ['All'],
    submenu: [],
  },

  // Admin Modules

  {
    path: '',
    title: 'MENUITEMS.DASHBOARD.TEXT',
    moduleName: 'dashboard',
    iconType: 'material-icons-two-tone',
    icon: 'space_dashboard',
    class: 'menu-toggle',
    groupTitle: false,
    badge: '',
    badgeClass: '',
    role: ['Admin'],
    submenu: [],
  },
 
  // Customer Modules

  {
    path: '/customer/dashboard',
    title: 'MENUITEMS.CUSTOMER.LIST.DASHBOARD',
    moduleName: 'dashboard',
    iconType: 'material-icons-two-tone',
    icon: 'space_dashboard',
    class: '',
    groupTitle: false,
    badge: '',
    badgeClass: '',
    role: ['Customer'],
    submenu: [],
  },

  // Common Module

  {
    path: '',
    title: 'Authentication',
    moduleName: 'authentication',
    iconType: 'material-icons-two-tone',
    icon: 'supervised_user_circle',
    class: 'menu-toggle',
    groupTitle: false,
    badge: '',
    badgeClass: '',
    role: ['Admin'],
    submenu: [
      {
        path: '/authentication/signin',
        title: 'Sign In',
        moduleName: 'authentication',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        role: [''],
        submenu: [],
      },
      {
        path: '/authentication/signup',
        title: 'Sign Up',
        moduleName: 'authentication',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        role: [''],
        submenu: [],
      },
      {
        path: '/authentication/forgot-password',
        title: 'Forgot Password',
        moduleName: 'authentication',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        role: [''],
        submenu: [],
      },
      {
        path: '/authentication/locked',
        title: 'Locked',
        moduleName: 'authentication',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        role: [''],
        submenu: [],
      },
      {
        path: '/authentication/page404',
        title: '404 - Not Found',
        moduleName: 'authentication',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        role: [''],
        submenu: [],
      },
      {
        path: '/authentication/page500',
        title: '500 - Server Error',
        moduleName: 'authentication',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        role: [''],
        submenu: [],
      },
    ],
  },
];
