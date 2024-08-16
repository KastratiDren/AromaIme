import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '@/views/HomeView.vue';
import FragrancesView from '@/views/FragrancesView.vue';
import NotFoundView from '@/views/NotFoundView.vue';
import FragranceView from '@/views/FragranceView.vue';
import AddFragranceView from '@/views/AddFragranceView.vue';
import EditFragranceView from '@/views/EditFragranceView.vue';
import RegisterView from '@/views/RegisterView.vue';
import LoginView from '@/views/LoginView.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/fragrances',
      name: 'fragrances',
      component: FragrancesView
    },
    {
      path: '/fragrances/:id',
      name: 'fragrance',
      component: FragranceView
    },
    {
      path: '/fragrances/add',
      name: 'add-fragrance',
      component: AddFragranceView,
      meta: { requiresAuth: true },
    },
    {
      path: '/fragrances/edit/:id',
      name: 'edit-fragrance',
      component: EditFragranceView,
      meta: { requiresAuth: true },
    },
    {
      path: '/register',
      name: 'resgister',
      component: RegisterView
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView
    },
    {
      path: '/:catchAll(.*)',
      name: 'not-found',
      component: NotFoundView,
    },
  ]
});

router.beforeEach(async (to, from, next) => {
  const token = localStorage.getItem('token');
  if (to.matched.some(record => record.meta.requiresAuth)) {
    if (!token) {
      next('/login');
    } else {
      // Decode the token to get the user's role
      const userRole = JSON.parse(atob(token.split('.')[1])).role;
      if (to.matched.some(record => record.meta.requiresAdmin) && userRole !== 'Admin') {
        next('/unauthorized');
      } else {
        next();
      }
    }
  } else {
    next();
  }
});

export default router
