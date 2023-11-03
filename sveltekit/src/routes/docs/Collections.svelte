<script lang="ts">
	import { base } from '$app/paths';
	import Link from '$lib/Link.svelte';

	const example1 = `
// Bosses
// Shadow (spoiler)
512
// Shadow (spoiler)
513
// Shadow (spoiler)
514
// Shadow (spoiler)
515
...`.trim();

	const example2 = `
encounter["Bosses"]:
  music = 42
end`.trim();
</script>

<h3>Collections</h3>
<div class="row">
	<div class="column">
		<p>
			<b>Collections</b> are text files that contain a list of numbers, usually some sort of ID. For
			example, the included collections contain lists of encounter IDs.
		</p>
	</div>
	<div class="column">
		<small><em>/Resources/Persona 4 Golden PC x64/collections/Bosses.enc</em></small>
		<pre><code>{example1}</code></pre>
	</div>
</div>
<div class="row">
	<div class="column">
		<h4>Using Collections</h4>
		<p>
			Collections let you make changes to multiple items at once, instead of one by one. For
			example, you can change the music for all boss battles by using the <code>Bosses</code> collection.
		</p>
		<pre><code>{example2}</code></pre>
		<p>
			<Link url="{base}/docs/collections">Find all available collections here.</Link>
		</p>
	</div>
</div>
