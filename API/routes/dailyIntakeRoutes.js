import express from 'express'
import { getDailyIntakes, getDailyIntake, search, createDailyIntake, deleteDailyIntake, updateDailyIntake } from '../controllers/dailyIntakeController.js'
import { authenticate } from '../middlewares/Authenticator.js';

const router = express.Router();

router.get('/', authenticate, getDailyIntakes);

router.get('/search/:id', authenticate, getDailyIntake)

router.get('/search', authenticate, search)

router.post('/', authenticate, createDailyIntake)

router.delete('/:id', authenticate, deleteDailyIntake)

router.put('/:id', authenticate, updateDailyIntake)

export default router;