import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '@/views/HomeView.vue';
import FragrancesView from '@/views/FragrancesView.vue';
import NotFoundView from '@/views/NotFoundView.vue';
import FragranceView from '@/views/FragranceView.vue';
import AddFragranceView from '@/views/AddFragranceView.vue';
import EditFragranceView from '@/views/EditFragranceView.vue';
import RegisterView from '@/views/RegisterView.vue';
import LoginView from '@/views/LoginView.vue';
import UnauthorizedView from '@/views/UnauthorizedView.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
      meta: { public: true },
    },
    {
      path: '/fragrances',
      name: 'fragrances',
      component: FragrancesView,
      meta: { public: true },
    },
    {
      path: '/fragrances/:id',
      name: 'fragrance',
      component: FragranceView,
      meta: { requiresAuth: true },
    },
    {
      path: '/fragrances/add',
      name: 'add-fragrance',
      component: AddFragranceView,
      meta: { requiresAuth: true, requiresRole: 'Admin' },
    },
    {
      path: '/fragrances/edit/:id',
      name: 'edit-fragrance',
      component: EditFragranceView,
      meta: { requiresAuth: true, requiresRole: 'Admin' },
    },
    {
      path: '/register',
      name: 'resgister',
      component: RegisterView,
      meta: { public: true },
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView,
      meta: { public: true },
    },
    {
      path: '/unauthorized',
      name: 'unauthorized',
      component: UnauthorizedView,
      meta: { public: true }, // Unauthorized view is public
    },
    {
      path: '/:catchAll(.*)',
      name: 'not-found',
      component: NotFoundView,
      meta: { public: true },
    },
  ]
});

router.beforeEach(async (to, from, next) => {
  const token = localStorage.getItem('token');
  const role = localStorage.getItem('role');
  const isAuthenticated = !!token;
  
  if (to.matched.some(record => record.meta.public)) {
    next(); // Allow public routes
  } else if (to.matched.some(record => record.meta.requiresAuth)) {
    if (!isAuthenticated) {
      next('/login'); // Redirect to login if not authenticated
    } else {
      if (to.matched.some(record => record.meta.requiresRole && record.meta.requiresRole !== role)) {
        next('/unauthorized'); // Redirect to unauthorized if role doesn't match
      } else {
        next(); // Allow route if authenticated and role matches
      }
    }
  } else {
    next(); // Fallback, should never reach here if meta fields are correctly set
  }
});


export default router
