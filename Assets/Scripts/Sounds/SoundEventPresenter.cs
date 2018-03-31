using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

namespace Sounds
{
    public class SoundEventPresenter : MonoBehaviour
    {
        [Inject]
        private void Initialize(ISoundPlayer soundPlayer, IBgmEventProvider bgmEventProvider, List<ISeEventProvider> seEventProviders)
        {
            seEventProviders.Select(x => x.PlaySeTriggerAsObservable())
                .Merge()
                .Subscribe(soundPlayer.PlayOneShot)
                .AddTo(this);

            bgmEventProvider.PlayBgmTriggerAsObservable()
                .TakeUntilDestroy(this)
                .Subscribe(soundPlayer.Play, soundPlayer.Stop);
        }
    }
}
