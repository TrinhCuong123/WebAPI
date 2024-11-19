import type { RestData, RestBase } from '~/models/base-response.model'
import type { TEMPDTO } from '~/models/request/tempDTO.model.ts'

class _TempService {
  async list() {
    console.log(111);
    const response = await $fetch<RestData<TEMPDTO[]>>(
        `https://localhost:5279/api/stock`,
        {
            method: 'GET',
        },
    );
    console.log(response)
    if (response && response.status) {
        return response.data;
    }
    return [];
  }
}
const TempService = new _TempService();
export default TempService;