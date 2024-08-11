import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '@/views/HomeView.vue';
import FragrancesView from '@/views/FragrancesView.vue';
import NotFoundView from '@/views/NotFoundView.vue';
import FragranceView from '@/views/FragranceView.vue';
import AddFragranceView from '@/views/AddFragranceView.vue';

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
      component: AddFragranceView
    },
    {
      path: '/:catchAll(.*)',
      name: 'not-found',
      component: NotFoundView,
    },
  ]
})

export default router
